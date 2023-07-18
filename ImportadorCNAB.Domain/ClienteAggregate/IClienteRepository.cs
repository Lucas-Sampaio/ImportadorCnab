using ImportadorCNAB.Domain.seedWork;

namespace ImportadorCNAB.Domain.ClienteAggregate;

public interface IClienteRepository : IRepository<Cliente>
{
    ValueTask AdicionarClientesAsync(List<Cliente> clientes, CancellationToken cancellation);
    ValueTask AtualizarClientesAsync(List<Cliente> clientes, CancellationToken cancellation);
    ValueTask<List<Cliente>> ObterClientes(IEnumerable<string> nomesLoja, CancellationToken cancellation);
    ValueTask<List<TipoTransacao>> ObterTiposTransacoes(IEnumerable<int> codigos, CancellationToken cancellation);
}