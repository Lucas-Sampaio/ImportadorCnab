using FluentValidation.Results;
using ImportadorCNAB.Api.Application.Commands.ArquivoCnabComand;
using ImportadorCNAB.Api.Controllers;
using ImportadorCNAB.Shared.Communication.Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ImportadorCNAB.Tests.ApiTests;

public class ImportadorControllerTest
{
    private readonly Mock<IMediatorHandler> _mediatorMock;
    private ImportadorCnabController _importadorController;

    public ImportadorControllerTest()
    {
        _mediatorMock = new Mock<IMediatorHandler>();
        _importadorController = new ImportadorCnabController(_mediatorMock.Object);
    }

    [Trait("Api", "ImportadorController teste")]
    [Fact(DisplayName = nameof(ImportarArquivo_Ocorre_com_sucesso))]
    public async Task ImportarArquivo_Ocorre_com_sucesso()
    {
        //arrange
        IFormFile file = null;
        var command = new ProcessarArquivoCnabCommand(file);
        var cancelation = new CancellationTokenSource().Token;

        _ = _mediatorMock.Setup
            (
            x => x.EnviarComando(
                It.IsAny<ProcessarArquivoCnabCommand>(),
                It.Is<CancellationToken>(y => y == cancelation))
            ).ReturnsAsync(new ValidationResult());

        //action
        var response = await _importadorController.Post(file, cancelation);

        //action
        Assert.IsType<OkResult>(response);

        _mediatorMock.Verify
          (
         x => x.EnviarComando(
                It.IsAny<ProcessarArquivoCnabCommand>(),
                It.Is<CancellationToken>(y => y == cancelation))
          , Times.Once);
    }

    [Trait("Api", "ImportadorController teste")]
    [Fact(DisplayName = nameof(ImportarArquivo_Ocorre_com_erro))]
    public async Task ImportarArquivo_Ocorre_com_erro()
    {
        //arrange
        IFormFile file = null;
        var command = new ProcessarArquivoCnabCommand(file);
        var cancelation = new CancellationTokenSource().Token;
        var validationErro = new ValidationResult();
        validationErro.Errors.Add(new ValidationFailure("teste", "erro teste"));

        _ = _mediatorMock.Setup
            (
            x => x.EnviarComando(
                It.IsAny<ProcessarArquivoCnabCommand>(),
                It.Is<CancellationToken>(y => y == cancelation))
            ).ReturnsAsync(validationErro);

        //action
        var response = await _importadorController.Post(file, cancelation);

        //action
        Assert.IsType<BadRequestObjectResult>(response);
        Assert.NotNull(((BadRequestObjectResult)response).Value);

        _mediatorMock.Verify
          (
         x => x.EnviarComando(
                It.IsAny<ProcessarArquivoCnabCommand>(),
                It.Is<CancellationToken>(y => y == cancelation))
          , Times.Once);
    }
}