using FluentValidation.Results;
using ImportadorCNAB.Domain.ClienteAggregate;
using ImportadorCNAB.Shared.Communication.Mediator;
using ImportadorCNAB.Shared.Communication.Messages;
using ImportadorCNAB.Shared.Utils;
using MediatR;

namespace ImportadorCNAB.Api.Application.Commands.ArquivoCnabComand;

public class ArquivoCnabCommandHandler : CommandHandler,
    IRequestHandler<ProcessarArquivoCnabCommand, ValidationResult>
{
    private readonly IClienteRepository _clienteRepository;

    public ArquivoCnabCommandHandler(IMediatorHandler mediatorHandler, IClienteRepository clienteRepository) : base(mediatorHandler)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ValidationResult> Handle(ProcessarArquivoCnabCommand request, CancellationToken cancellationToken)
    {
        if (!request.EhValido()) return request.ValidationResult;

        var linhasArquivo = await ObterLinhasArquivoAsync(request.Arquivo, cancellationToken);
        var clientesArquivo = await ObterClientesArquivo(linhasArquivo, cancellationToken);

        var clientesParaAtualizar = await ObterClientesParaAtualizar(clientesArquivo, cancellationToken);
        var clientesNovos = ObterClientesNovos(clientesArquivo, clientesParaAtualizar);

        await _clienteRepository.AtualizarClientesAsync(clientesParaAtualizar, cancellationToken);

        await _clienteRepository.AdicionarClientesAsync(clientesNovos.ToList(), cancellationToken);
        await _clienteRepository.UnitOfWork.CommitAsync();

        return request.ValidationResult;
    }

    private IEnumerable<Cliente> ObterClientesNovos(IEnumerable<Cliente> clientesArquivo, List<Cliente> clientesParaAtualizar)
    {
        var nomesLoja = clientesParaAtualizar.Select(x => x.NomeLoja);

        var clienteNovos = clientesArquivo.Where(x => !nomesLoja.Contains(x.NomeLoja));
        return clienteNovos;
    }

    private async ValueTask<IEnumerable<string>> ObterLinhasArquivoAsync(IFormFile file, CancellationToken cancellation)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        var linhas = await reader.ObterLinhasAsync(cancellation);
        return linhas;
    }

    private async ValueTask<IEnumerable<Cliente>> ObterClientesArquivo(IEnumerable<string> linhas, CancellationToken cancellation)
    {
        var clientes = new List<Cliente>();
        var tipoTransacoes = await ObterTiposTransacoes(linhas, cancellation);

        foreach (var linha in linhas)
        {
            var NomeLoja = linha.CnabObterNomeLoja();
            Cliente? cliente = clientes.Find(x => x.NomeLoja == NomeLoja);

            if (cliente is null)
            {
                cliente = ObterClienteArquivo(linha);
                clientes.Add(cliente);
            }

            var transacao = ObterTransacao(linha, tipoTransacoes);
            cliente.AdicionarTransacao(transacao);
        }

        return clientes;
    }

    private async ValueTask<List<Cliente>> ObterClientesParaAtualizar(IEnumerable<Cliente> clientesArquivo, CancellationToken cancellation)
    {
        var nomesLoja = clientesArquivo.Select(x => x.NomeLoja);

        var clientesExistentes = await _clienteRepository.ObterClientes(nomesLoja, cancellation);

        foreach (var cliente in clientesExistentes)
        {
            var transacoes = clientesArquivo
                .FirstOrDefault(x => x.NomeLoja == cliente.NomeLoja)?.Transacoes;

            if (transacoes is not null)
                cliente.AdicionarTransacoes(transacoes);
        }

        return clientesExistentes;
    }

    private Cliente ObterClienteArquivo(string linha)
    {
        var donoLoja = linha.CnabObterNomeDonoLoja();
        var NomeLoja = linha.CnabObterNomeLoja();
        var cpf = linha.CnabObterCpf();
        var cliente = new Cliente(NomeLoja.Trim(), donoLoja.Trim(), new CPF(cpf));
        return cliente;
    }

    private Transacao ObterTransacao(string linha, List<TipoTransacao> tipoTransacoes)
    {
        var codigo = linha.CnabObterTipo();
        var tipo = tipoTransacoes.Find(x => x.Codigo == codigo.ToInt32(0));
        var data = linha.CnabObterData();
        var valor = linha.CnabObterValor();
        var cartao = linha.CnabObterCartao();
        var transacao = new Transacao(data, valor.ToDecimal(), cartao, tipo!);
        return transacao;
    }

    private async ValueTask<List<TipoTransacao>> ObterTiposTransacoes(IEnumerable<string> linhas, CancellationToken cancellation)
    {
        var codigos = linhas.Select(x => x.CnabObterTipo().ToInt32()).Distinct();
        var tiposTransacoes = await _clienteRepository
            .ObterTiposTransacoes(codigos, cancellation);

        return tiposTransacoes;
    }
}