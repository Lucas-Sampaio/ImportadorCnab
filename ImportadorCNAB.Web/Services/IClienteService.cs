using ImportadorCNAB.Web.Models;

namespace ImportadorCNAB.Web.Services;

public interface IClienteService
{
    ValueTask<(List<LojaVM> lojas, string? erro)> ObterLojas();
    ValueTask<(ClienteVM cliente, string? erro)> ObterCliente(int id);
}
