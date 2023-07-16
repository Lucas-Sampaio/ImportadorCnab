using ImportadorCNAB.Domain.ClienteAggregate;
using ImportadorCNAB.Domain.Shared.Enums;
using Xunit;

namespace ImportadorCNAB.Tests.DomainTests;

public class TipoTransacaoTestes
{
    [Trait("Domain", "Tipo Transacao teste")]
    [Fact(DisplayName = nameof(TipoTransacaoPositiva_Construido_com_sucesso))]
    public void TipoTransacaoPositiva_Construido_com_sucesso()
    {
        //Arrange
        var codigo = 10;
        var descricao = "boleto";

        //Act
        TipoTransacao tipo = new TransacaoPositiva(codigo, descricao);

        //Assert
        Assert.Equal(codigo, tipo.Codigo);
        Assert.Equal(descricao, tipo.Descricao);
        Assert.Equal(0, tipo.Id);
        Assert.Equal(ENatureza.Entrada, tipo.Natureza);
        Assert.NotNull(tipo);
        Assert.IsType<TransacaoPositiva>(tipo);
    }

    [Trait("Domain", "Tipo Transacao teste")]
    [Fact(DisplayName = nameof(TipoTransacaoNegativa_Construido_com_sucesso))]
    public void TipoTransacaoNegativa_Construido_com_sucesso()
    {
        //Arrange
        var codigo = 10;
        var descricao = "boleto";
        var id = 11;

        //Act
        TipoTransacao tipo = new TransacaoNegativa(codigo, descricao, id);

        //Assert
        Assert.Equal(codigo, tipo.Codigo);
        Assert.Equal(descricao, tipo.Descricao);
        Assert.Equal(id, tipo.Id);
        Assert.Equal(ENatureza.Saida, tipo.Natureza);
        Assert.NotNull(tipo);
        Assert.IsType<TransacaoNegativa>(tipo);
    }
}