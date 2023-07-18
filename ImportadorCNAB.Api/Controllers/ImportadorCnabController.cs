using ImportadorCNAB.Api.Application.Commands.ArquivoCnabComand;
using ImportadorCNAB.Shared.Communication.Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImportadorCNAB.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImportadorCnabController : ControllerBase
{
    private readonly IMediatorHandler _mediator;

    public ImportadorCnabController(IMediatorHandler mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("")]
    public async Task<IActionResult> Post(IFormFile file)
    {
        var comando = new ProcessarArquivoCnabCommand(file);

        await _mediator.EnviarComando(comando);
        return Ok();
    }
}