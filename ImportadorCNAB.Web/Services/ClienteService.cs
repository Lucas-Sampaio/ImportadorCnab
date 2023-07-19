using ImportadorCNAB.Web.Models;

namespace ImportadorCNAB.Web.Services;

public class ClienteService : ServiceBase, IClienteService
{
    private readonly HttpClient _httpClient;

    public ClienteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async ValueTask<(ClienteVM cliente, string? erro)> ObterCliente(int id)
    {
        var response = await _httpClient.GetAsync($"/api/Cliente/{id}");
        if (response.IsSuccessStatusCode)
        {
            var cliente = await DeserializarObjetoResponse<ClienteVM>(response);
            return (cliente, "");
        }
        else
        {
            var erro = await response.Content.ReadAsStringAsync();
            return (null, erro);
        }
    }

    public async ValueTask<(List<LojaVM> lojas, string? erro)> ObterLojas()
    {
        var response = await _httpClient.GetAsync("api/Cliente/ObterLojas");
        if (response.IsSuccessStatusCode)
        {
            var lojas = await DeserializarObjetoResponse<List<LojaVM>>(response);
            return (lojas, "");
        }
        else
        {
            var erro = await response.Content.ReadAsStringAsync();
            return (null, erro);
        }
    }
}