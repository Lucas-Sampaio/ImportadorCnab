using ImportadorCNAB.Domain.ClienteAggregate;
using ImportadorCNAB.Domain.seedWork;

namespace ImportadorCNAB.Infra.Repositories;

internal class ClienteRepository : IClienteRepository
{
    private readonly ClienteContext _context;

    public ClienteRepository(ClienteContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async ValueTask AdicionarClienteAsync(Cliente cliente) =>
        await _context.Clientes.AddAsync(cliente);

    public async ValueTask AdicionarClientesAsync(List<Cliente> clientes) =>
        await _context.Clientes.AddRangeAsync(clientes);

    public ValueTask AdicionarTransacoesAsync(int clienteId, List<Transacao> transacoes)
    {
                throw new NotImplementedException();
    }
}