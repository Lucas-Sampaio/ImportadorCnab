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

    /// <summary>
    /// Obtem o nome de todas as lojas importadas
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns>lista de loja com id e nome</returns>
    /// <response code="200">Retorna status code 200 com uma lista de loja</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("ObterLojas")]
    public async Task<IActionResult> GetLojas(CancellationToken cancellation)
    {
        var lojas = await _clienteQuery.ObterLojas(cancellation);

        return Ok(lojas);
    }

    /// <summary>
    /// Obtem o cliente pelo id
    /// </summary>
    /// <param name="clienteId">Id do cliente</param>
    /// <param name="cancellation"></param>
    /// <returns>Um cliente com sua transacoes</returns>
    /// <response code="200">Retorna status code 200 com info do cliente</response>
    /// <response code="404">Retorna status code 404</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{clienteId}")]
    public async Task<IActionResult> GetCliente(int clienteId, CancellationToken cancellation)
    {
        var cliente = await _clienteQuery.ObterCliente(clienteId, cancellation);
        if (cliente is null)
            return NotFound();

        return Ok(cliente);
    }
}