using ImportadorCNAB.Domain.ClienteAggregate;
using ImportadorCNAB.Domain.Shared.Enums;
using Xunit;

namespace ImportadorCNAB.Tests.DomainTests;

public class TransacaoTestes
{
    [Trait("Domain", "Transacao teste")]
    [Fact(DisplayName = nameof(Transacao_Construido_com_sucesso))]
    public void Transacao_Construido_com_sucesso()
    {
        //Arrange
        var data = DateTimeOffset.UtcNow;
        var valor = 10;
        var cartao = "152128498";
        var tipo = ETipoTransacao.Debito;

        //Act
        var transacao = new Transacao(data, valor, cartao, tipo);

        //Assert
        Assert.Equal(data, transacao.Data);
        Assert.Equal(valor, transacao.Valor);
        Assert.Equal(cartao, transacao.CartaoUtilizadoNumero);
        Assert.Equal(tipo, transacao.TipoTransacao);
        Assert.NotNull(transacao);
    }
}