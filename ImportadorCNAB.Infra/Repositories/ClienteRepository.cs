using ImportadorCNAB.Domain.ClienteAggregate;
using ImportadorCNAB.Domain.seedWork;
using Microsoft.EntityFrameworkCore;

namespace ImportadorCNAB.Infra.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly ClienteContext _context;

    public ClienteRepository(ClienteContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async ValueTask AdicionarClientesAsync(List<Cliente> clientes, CancellationToken cancellation) =>
        await _context.Clientes.AddRangeAsync(clientes, cancellation);

    public ValueTask AtualizarClientesAsync(List<Cliente> clientes, CancellationToken cancellation)
    {
        _context.Clientes.UpdateRange(clientes);
        return ValueTask.CompletedTask;
    }

    public async ValueTask<List<Cliente>> ObterClientes(IEnumerable<string> nomesLoja, CancellationToken cancellation) =>
        await _context.Clientes
          .Include(x => x.Transacoes)
          .Where(x => nomesLoja.Contains(x.NomeLoja))
          .ToListAsync(cancellation);

    public async ValueTask<List<TipoTransacao>> ObterTiposTransacoes(IEnumerable<int> codigos,
        CancellationToken cancellation) =>
        await _context.TiposTransacoes
          .Where(x => codigos.Contains(x.Codigo))
          .ToListAsync(cancellation);
}