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
    /// <summary>
    /// Importar um arquivo cnab para uma base de dados
    /// </summary>
    /// <param name="file">arquivo cnab txt</param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    /// <response code="200">Retorna status code 200</response>
    /// <response code="400">Retorna um objeto com o erro</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest,Type = typeof(ValidationProblemDetails))]
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