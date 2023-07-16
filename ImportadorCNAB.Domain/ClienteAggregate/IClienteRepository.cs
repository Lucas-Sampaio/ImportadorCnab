using ImportadorCNAB.Domain.seedWork;

namespace ImportadorCNAB.Domain.ClienteAggregate;

public interface IClienteRepository : IRepository<Cliente>
{
    ValueTask AdicionarClienteAsync(Cliente cliente);
    ValueTask AdicionarClientesAsync(List<Cliente> clientes);
    ValueTask AdicionarTransacoesAsync(int clienteId, List<Transacao> transacoes);
}