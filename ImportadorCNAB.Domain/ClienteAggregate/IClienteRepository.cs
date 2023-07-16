using ImportadorCNAB.Domain.seedWork;

namespace ImportadorCNAB.Domain.ClienteAggregate;

public interface IClienteRepository : IRepository<Cliente>
{
    ValueTask AdicionarCliente(Cliente cliente);
}