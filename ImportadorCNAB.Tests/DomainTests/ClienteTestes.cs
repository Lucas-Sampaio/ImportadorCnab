using ImportadorCNAB.Domain.ClienteAggregate;
using Xunit;

namespace ImportadorCNAB.Tests.DomainTests;

public class ClienteTestes
{
    [Trait("Domain", "Cliente teste")]
    [Fact(DisplayName = nameof(Cliente_Construido_com_sucesso))]
    public void Cliente_Construido_com_sucesso()
    {
        //Arrange
        var nomeloja = "nomeLoja";
        var nome = "nome";
        var cpf = new CPF("961.232.190-65");

        //Act
        var cliente = new Cliente(nomeloja, nome, cpf);

        //Assert
        Assert.Equal(nome, cliente.Nome);
        Assert.Equal(nomeloja, cliente.NomeLoja);
        Assert.Equal(cpf, cliente.Cpf);
        Assert.NotNull(cliente);
    }

    [Trait("Domain", "Cliente teste")]
    [Fact(DisplayName = nameof(Cliente_Adiciona_Transacao_com_sucesso))]
    public void Cliente_Adiciona_Transacao_com_sucesso()
    {
        //Arrange
        var nomeloja = "nomeLoja";
        var nome = "nome";
        var cpf = new CPF("961.232.190-65");
        var transacao1 = new Transacao(DateTimeOffset.UtcNow, 10, "123456", new TransacaoPositiva(1, "teste"));
        var transacao2 = new Transacao(DateTimeOffset.UtcNow, 10, "123456", new TransacaoNegativa(2, "testeN"));
        var cliente = new Cliente(nomeloja, nome, cpf);

        //Act
        cliente.AdicionarTransacao(transacao1);
        cliente.AdicionarTransacao(transacao2);

        //Assert
        Assert.Equal(nome, cliente.Nome);
        Assert.Equal(nomeloja, cliente.NomeLoja);
        Assert.Equal(cpf, cliente.Cpf);
        Assert.NotNull(cliente);
        Assert.NotEmpty(cliente.Transacoes);
        Assert.Equal(2, cliente.Transacoes.Count);
        Assert.Collection(cliente.Transacoes,
            item => Assert.IsType<TransacaoPositiva>(item.TipoTransacao),
            item => Assert.IsType<TransacaoNegativa>(item.TipoTransacao));
    }

    [Trait("Domain", "Cliente teste")]
    [Fact(DisplayName = nameof(Cliente_Calcula_valor_saldo_certo))]
    public void Cliente_Calcula_valor_saldo_certo()
    {
        //Arrange
        var nomeloja = "nomeLoja";
        var nome = "nome";
        var cpf = new CPF("961.232.190-65");
        var valorP1 = 100;
        var valorP2 = 200;
        var valorN1 = 100;
        var valorN2 = 50.80M;
        var totalEsperado = valorP1 + valorP2 - (valorN1 + valorN2);
        var transacao1 = new Transacao(DateTimeOffset.UtcNow, valorP1, "123456", new TransacaoPositiva(1, "teste"));
        var transacao2 = new Transacao(DateTimeOffset.UtcNow, valorP2, "123456", new TransacaoPositiva(1, "teste"));
        var transacao3 = new Transacao(DateTimeOffset.UtcNow, valorN1, "123456", new TransacaoNegativa(2, "testeN"));
        var transacao4 = new Transacao(DateTimeOffset.UtcNow, valorN2, "123456", new TransacaoNegativa(2, "testeN"));
        var cliente = new Cliente(nomeloja, nome, cpf);

        //Act
        cliente.AdicionarTransacao(transacao1);
        cliente.AdicionarTransacao(transacao2);
        cliente.AdicionarTransacao(transacao3);
        cliente.AdicionarTransacao(transacao4);

        //Assert
        Assert.Equal(nome, cliente.Nome);
        Assert.Equal(nomeloja, cliente.NomeLoja);
        Assert.Equal(cpf, cliente.Cpf);
        Assert.NotNull(cliente);
        Assert.NotEmpty(cliente.Transacoes);
        Assert.Equal(totalEsperado, cliente.ObterValorTotalSaldo());
    }
}