using ImportadorCNAB.Api.Application.Queries;
using ImportadorCNAB.Domain.ClienteAggregate;
using Moq;
using Xunit;

namespace ImportadorCNAB.Tests.ApiTests;

public class ClienteQueryTest
{
    private readonly Mock<IClienteRepository> _clienteRepoMock;
    private IClienteQuery _clienteQuery;

    public ClienteQueryTest()
    {
        _clienteRepoMock = new Mock<IClienteRepository>();
        _clienteQuery = new ClienteQuery(_clienteRepoMock.Object);
    }

    [Trait("Api", "ClienteQuery teste")]
    [Fact(DisplayName = nameof(Obtem_Lojas_com_sucesso))]
    public async Task Obtem_Lojas_com_sucesso()
    {
        //arrange
        var lojas = new List<(int id, string nome)>(2)
        {
           (1,"loja 1"),
           (2,"loja 2")
        };

        var cancelation = new CancellationTokenSource().Token;

        _ = _clienteRepoMock.Setup
            (
            x => x.ObterLojas(
                It.Is<CancellationToken>(y => y == cancelation))
            ).ReturnsAsync(lojas);

        //action
        var response = await _clienteQuery.ObterLojas(cancelation);

        //action

        Assert.NotNull(response);
        Assert.Equal(2, lojas.Count);

        _clienteRepoMock.Verify
          (
                x => x.ObterLojas(
                It.Is<CancellationToken>(y => y == cancelation))
          , Times.Once);
    }

    [Trait("Api", "ClienteQuery teste")]
    [Fact(DisplayName = nameof(Obtem_cliente_com_sucesso))]
    public async Task Obtem_cliente_com_sucesso()
    {
        //arrange
        var lojas = new List<(int id, string nome)>(2)
        {
           (1,"loja 1"),
           (2,"loja 2")
        };

        var id = 10;
        var nomeLoja = "loja teste";
        var nomeCliente = "teste";
        var cliente = new Cliente(nomeLoja, nomeCliente, new CPF("76023030084"));
        cliente.AdicionarTransacao(new Transacao(DateTimeOffset.Now, 10, "", new TransacaoPositiva(1, "teste")));
        var cancelation = new CancellationTokenSource().Token;

        _ = _clienteRepoMock.Setup
            (
            x => x.ObterCliente(
                It.Is<int>(x => x == id),
                It.Is<CancellationToken>(y => y == cancelation))
            ).ReturnsAsync(cliente);

        //action
        var response = await _clienteQuery.ObterCliente(id, cancelation);

        //action

        Assert.NotNull(response);
        Assert.Equal(nomeLoja, response.NomeLoja);
        Assert.NotEmpty(cliente.Transacoes);
        Assert.Collection(cliente.Transacoes,
            x => Assert.IsType<TransacaoPositiva>(x.TipoTransacao));

        _clienteRepoMock.Verify
          (
                x => x.ObterCliente(
                 It.Is<int>(x => x == id),
                 It.Is<CancellationToken>(y => y == cancelation))
          , Times.Once);
    }
}