using ImportadorCNAB.Api.Application.Dtos;
using ImportadorCNAB.Domain.ClienteAggregate;

namespace ImportadorCNAB.Api.Application.Queries;

public class ClienteQuery : IClienteQuery
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteQuery(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async ValueTask<ClienteDto?> ObterCliente(int clienteId, CancellationToken ct)
    {
        var cliente = await _clienteRepository.ObterCliente(clienteId, ct);
        if (cliente is null) return null;

        return new ClienteDto
        {
            Id = cliente.Id,
            NomeLoja = cliente.NomeLoja,
            SaldoTotal = cliente.ObterValorTotalSaldo(),
            Transacoes = cliente.Transacoes.Select(x =>
            new TransacaoDto
            {
                Cartao = x.CartaoUtilizadoNumero,
                Data = x.Data.DateTime, //x.Data.LocalDateTime,
                TipoTransacao = x.TipoTransacao.Descricao,
                Valor = x.Valor
            }).ToList()
        };
    }

    public async ValueTask<IEnumerable<LojaDto>> ObterLojas(CancellationToken ct)
    {
        var lojas = await _clienteRepository.ObterLojas(ct);
        return lojas
            .Select(x =>
                new LojaDto
                {
                    Id = x.id,
                    NomeLoja = x.nomeLoja
                });
    }
}