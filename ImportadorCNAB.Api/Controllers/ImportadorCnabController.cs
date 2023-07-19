using FluentValidation.Results;
using ImportadorCNAB.Api.Application.Commands.ArquivoCnabComand;
using ImportadorCNAB.Shared.Communication.Mediator;
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
    public async Task<IActionResult> Post(IFormFile file, CancellationToken cancellation)
    {
        var comando = new ProcessarArquivoCnabCommand(file);

        var result = await _mediator.EnviarComando(comando, cancellation);
        if (!result.IsValid)
            return BadRequest(CriarMsgErro(result));

        return Ok();
    }

    private ValidationProblemDetails CriarMsgErro(ValidationResult validationsResult)
    {
        return new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Mensagens", validationsResult.Errors.Select(x => x.ErrorMessage).ToArray()}
            });
    }
}