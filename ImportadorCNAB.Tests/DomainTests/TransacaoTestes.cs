using ImportadorCNAB.Domain.ClienteAggregate;
using ImportadorCNAB.Domain.Shared.Enums;
using Xunit;

namespace ImportadorCNAB.Tests.DomainTests;

public class TransacaoTestes
{
    [Trait("Domain", "Transacao teste")]
    [Fact(DisplayName = nameof(TransacaoPositiva_Construido_com_sucesso))]
    public void TransacaoPositiva_Construido_com_sucesso()
    {
        //Arrange
        var data = DateTimeOffset.UtcNow;
        var valor = 10;
        var cartao = "152128498";
        var tipo = new TransacaoPositiva(1,"boleto");

        //Act
        var transacao = new Transacao(data, valor, cartao, tipo);

        //Assert
        Assert.Equal(data, transacao.Data);
        Assert.Equal(valor, transacao.Valor);
        Assert.Equal(cartao, transacao.CartaoUtilizadoNumero);
        Assert.Equal(tipo.Codigo, transacao.TipoTransacao.Codigo);
        Assert.IsType<TransacaoPositiva>(transacao.TipoTransacao);
        Assert.NotNull(transacao);
    }

    [Trait("Domain", "Transacao teste")]
    [Fact(DisplayName = nameof(TransacaoNegativa_Construido_com_sucesso))]
    public void TransacaoNegativa_Construido_com_sucesso()
    {
        //Arrange
        var data = DateTimeOffset.UtcNow;
        var valor = 10;
        var cartao = "152128498";
        var tipo = new TransacaoNegativa(2, "boleto");

        //Act
        var transacao = new Transacao(data, valor, cartao, tipo);

        //Assert
        Assert.Equal(data, transacao.Data);
        Assert.Equal(valor, transacao.Valor);
        Assert.Equal(cartao, transacao.CartaoUtilizadoNumero);
        Assert.Equal(tipo.Codigo, transacao.TipoTransacao.Codigo);
        Assert.IsType<TransacaoNegativa>(transacao.TipoTransacao);
        Assert.NotNull(transacao);
    }
}