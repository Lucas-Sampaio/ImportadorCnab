using ImportadorCNAB.Api.Application.Dtos;
using ImportadorCNAB.Api.Application.Queries;
using ImportadorCNAB.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ImportadorCNAB.Tests.ApiTests;

public class ClienteControllerTest
{
    private readonly Mock<IClienteQuery> _clienteQueryMock;
    private ClienteController _clienteController;

    public ClienteControllerTest()
    {
        _clienteQueryMock = new Mock<IClienteQuery>();
        _clienteController = new ClienteController(_clienteQueryMock.Object);
    }

    [Trait("Api", "ClienteController teste")]
    [Fact(DisplayName = nameof(Obtem_Lojas_com_sucesso))]
    public async Task Obtem_Lojas_com_sucesso()
    {
        //arrange
        var lojas = new List<LojaDto>(2)
        {
           new LojaDto
           {
               Id = 1,
               NomeLoja = "loja 1"
           },
           new LojaDto
           {
               Id = 2,
               NomeLoja = "loja 2"
           }
        };

        var cancelation = new CancellationTokenSource().Token;

        _ = _clienteQueryMock.Setup
            (
            x => x.ObterLojas(
                It.Is<CancellationToken>(y => y == cancelation))
            ).ReturnsAsync(lojas);

        //action
        var response = await _clienteController.GetLojas(cancelation);

        //action
        var result = response as OkObjectResult;
        var valorRetornado = result?.Value as List<LojaDto>;

        Assert.IsType<OkObjectResult>(response);
        Assert.NotNull(result);
        Assert.NotNull(result.Value);
        Assert.NotNull(valorRetornado);
        Assert.Equal(2, valorRetornado.Count);

        _clienteQueryMock.Verify
          (
                x => x.ObterLojas(
                It.Is<CancellationToken>(y => y == cancelation))
          , Times.Once);
    }

    [Trait("Api", "ClienteController teste")]
    [Fact(DisplayName = nameof(Obtem_Cliente_com_sucesso))]
    public async Task Obtem_Cliente_com_sucesso()
    {
        //arrange
        var cliente = new ClienteDto()
        {
            Id = 1
        };

        var cancelation = new CancellationTokenSource().Token;

        _ = _clienteQueryMock.Setup
            (
            x => x.ObterCliente(
                It.Is<int>(x => x == cliente.Id),
                It.Is<CancellationToken>(y => y == cancelation))
            ).ReturnsAsync(cliente);

        //action
        var response = await _clienteController.GetCliente(cliente.Id, cancelation);

        //action
        var result = response as OkObjectResult;
        var valorRetornado = result?.Value as ClienteDto;

        Assert.IsType<OkObjectResult>(response);
        Assert.NotNull(result);
        Assert.NotNull(result.Value);
        Assert.NotNull(valorRetornado);
        Assert.Equal(cliente.Id, valorRetornado.Id);

        _clienteQueryMock.Verify
          (
                x => x.ObterCliente(
                It.Is<int>(x => x == cliente.Id),
                It.Is<CancellationToken>(y => y == cancelation))
          , Times.Once);
    }

    [Trait("Api", "ClienteController teste")]
    [Fact(DisplayName = nameof(Obtem_Cliente_nao_encontrado))]
    public async Task Obtem_Cliente_nao_encontrado()
    {
        //arrange
        var cliente = new ClienteDto()
        {
            Id = 1
        };

        var cancelation = new CancellationTokenSource().Token;

        _ = _clienteQueryMock.Setup
            (
            x => x.ObterCliente(
                It.Is<int>(x => x == cliente.Id),
                It.Is<CancellationToken>(y => y == cancelation))
            ).ReturnsAsync(cliente);

        //action
        var response = await _clienteController.GetCliente(cliente.Id, cancelation);

        //action
        var result = response as OkObjectResult;
        var valorRetornado = result?.Value as ClienteDto;

        Assert.IsType<OkObjectResult>(response);
        Assert.NotNull(result);
        Assert.NotNull(result.Value);
        Assert.NotNull(valorRetornado);
        Assert.Equal(cliente.Id, valorRetornado.Id);

        _clienteQueryMock.Verify
          (
                x => x.ObterCliente(
                It.Is<int>(x => x == cliente.Id),
                It.Is<CancellationToken>(y => y == cancelation))
          , Times.Once);
    }
}