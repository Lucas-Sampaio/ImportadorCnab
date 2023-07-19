using ImportadorCNAB.Api.Application.Dtos;

namespace ImportadorCNAB.Api.Application.Queries;

public interface IClienteQuery
{
    ValueTask<IEnumerable<LojaDto>> ObterLojas(CancellationToken ct);
    ValueTask<ClienteDto?> ObterCliente(int clienteId, CancellationToken ct);
}
