using ImportadorCNAB.Api.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ImportadorCNAB.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteQuery _clienteQuery;

    public ClienteController(IClienteQuery clienteQuery)
    {
        _clienteQuery = clienteQuery;
    }

    [HttpGet("ObterLojas")]
    public async Task<IActionResult> GetLojas(CancellationToken cancellation)
    {
        var lojas = await _clienteQuery.ObterLojas(cancellation);

        return Ok(lojas);
    }

    [HttpGet("{clienteId}")]
    public async Task<IActionResult> GetCliente(int clienteId, CancellationToken cancellation)
    {
        var cliente = await _clienteQuery.ObterCliente(clienteId, cancellation);
        if (cliente is null)
            return NotFound();

        return Ok(cliente);
    }
}