using ImportadorCNAB.Api.Application.Commands.ArquivoCnabComand;
using ImportadorCNAB.Domain.ClienteAggregate;
using ImportadorCNAB.Shared.Communication.Mediator;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Text;
using Xunit;

namespace ImportadorCNAB.Tests.ApiTests;

public class ArquivoCnabHandlerTest
{
    private readonly Mock<IClienteRepository> _clienteRepositoryMock;
    private readonly Mock<IMediatorHandler> _mediatorMock;
    private ArquivoCnabCommandHandler _arquivoCnabCommandHandler;

    public ArquivoCnabHandlerTest()
    {
        _clienteRepositoryMock = new Mock<IClienteRepository>();
        _mediatorMock = new Mock<IMediatorHandler>();
        _arquivoCnabCommandHandler = new ArquivoCnabCommandHandler(_mediatorMock.Object, _clienteRepositoryMock.Object);
    }

    [Trait("Api", "ArquivoCnabHandler teste")]
    [Fact(DisplayName = nameof(Processa_arquivo_cnab_com_sucesso))]
    public async Task Processa_arquivo_cnab_com_sucesso()
    {
        //arrange
        var bytes = Encoding.UTF8.GetBytes("5201903010000013200556418150633123****7687145607MARIA JOSEFINALOJA DO Ó - MATRIZ");
        using var ms = new MemoryStream(bytes);
        IFormFile file = new FormFile(ms, 0, bytes.Length, "cnab", "cnab.txt");
        var command = new ProcessarArquivoCnabCommand(file);

        var cancellation = new CancellationTokenSource().Token;
        ConfigurarClienteRepositoryMock(cancellation);

        //action
        var response = await _arquivoCnabCommandHandler.Handle(command, cancellation);

        //action

        Assert.NotNull(response);
        Assert.True(response.IsValid);

        _clienteRepositoryMock.Verify
         (
               x => x.ObterTiposTransacoes(
               It.IsAny<IEnumerable<int>>(),
               It.Is<CancellationToken>(y => y == cancellation))
         , Times.Once);

        _clienteRepositoryMock.Verify
         (
               x => x.ObterClientes(
              It.IsAny<IEnumerable<string>>(),
              It.Is<CancellationToken>(y => y == cancellation))
         , Times.Once);

        _clienteRepositoryMock.Verify
          (
                x => x.AdicionarClientesAsync(
                It.IsAny<List<Cliente>>(),
                It.Is<CancellationToken>(y => y == cancellation))
          , Times.Once);

        _clienteRepositoryMock.Verify
         (
               x => x.AtualizarClientesAsync(
               It.IsAny<List<Cliente>>(),
               It.Is<CancellationToken>(y => y == cancellation))
         , Times.Once);

        _clienteRepositoryMock.Verify
         (
               x => x.UnitOfWork.CommitAsync(
               It.Is<CancellationToken>(y => y == cancellation))
         , Times.Once);
    }

    [Trait("Api", "ArquivoCnabHandler teste")]
    [Fact(DisplayName = nameof(Processa_arquivo_cnab_com_erro))]
    public async Task Processa_arquivo_cnab_com_erro()
    {
        var bytes = Encoding.UTF8.GetBytes("");
        using var ms = new MemoryStream(bytes);

        IFormFile file = new FormFile(ms, 0, bytes.Length, "cnab", "cnab.txt");

        //arrange
        var command = new ProcessarArquivoCnabCommand(file);

        var cancellation = new CancellationTokenSource().Token;

        ConfigurarClienteRepositoryMock(cancellation);
        //action
        var response = await _arquivoCnabCommandHandler.Handle(command, cancellation);

        //action

        Assert.NotNull(response);
        Assert.False(response.IsValid);

        _clienteRepositoryMock.Verify
         (
               x => x.ObterTiposTransacoes(
               It.IsAny<IEnumerable<int>>(),
               It.Is<CancellationToken>(y => y == cancellation))
         , Times.Never);

        _clienteRepositoryMock.Verify
         (
               x => x.ObterClientes(
              It.IsAny<IEnumerable<string>>(),
              It.Is<CancellationToken>(y => y == cancellation))
         , Times.Never);

        _clienteRepositoryMock.Verify
          (
                x => x.AdicionarClientesAsync(
                It.IsAny<List<Cliente>>(),
                It.Is<CancellationToken>(y => y == cancellation))
          , Times.Never);

        _clienteRepositoryMock.Verify
         (
               x => x.AtualizarClientesAsync(
               It.IsAny<List<Cliente>>(),
               It.Is<CancellationToken>(y => y == cancellation))
         , Times.Never);

        _clienteRepositoryMock.Verify
         (
               x => x.UnitOfWork.CommitAsync(
               It.Is<CancellationToken>(y => y == cancellation))
         , Times.Never);
    }

    private void ConfigurarClienteRepositoryMock(CancellationToken cancellation)
    {
        var tiposTransacao = new List<TipoTransacao>(1)
        {
            new TransacaoPositiva(5,"boleto")
        };

        var clientes = new List<Cliente>(1)
        {
            new Cliente("loja teste", "nome teste", new CPF("961.232.190-65"))
        };

        _ = _clienteRepositoryMock.Setup
             (
             x => x.ObterTiposTransacoes(
                 It.IsAny<IEnumerable<int>>(),
                 It.Is<CancellationToken>(y => y == cancellation))
             ).ReturnsAsync(tiposTransacao);

        _ = _clienteRepositoryMock.Setup
          (
          x => x.ObterClientes(
              It.IsAny<IEnumerable<string>>(),
              It.Is<CancellationToken>(y => y == cancellation))
          ).ReturnsAsync(clientes);

        _ = _clienteRepositoryMock.Setup
            (
            x => x.AdicionarClientesAsync(
                It.IsAny<List<Cliente>>(),
                It.Is<CancellationToken>(y => y == cancellation))
            ).Returns(ValueTask.CompletedTask);

        _ = _clienteRepositoryMock.Setup
            (
            x => x.AtualizarClientesAsync(
                It.IsAny<List<Cliente>>(),
                It.Is<CancellationToken>(y => y == cancellation))
            ).Returns(ValueTask.CompletedTask);

        _ = _clienteRepositoryMock.Setup
           (
           x => x.UnitOfWork.CommitAsync(
               It.Is<CancellationToken>(y => y == cancellation))
           ).ReturnsAsync(true);
    }
}