using ImportadorCNAB.Shared.Utils;
using Xunit;

namespace ImportadorCNAB.Tests.SharedTests;

public class CnabExtensionsTests
{
    private const string linhaCnab = "3201903010000014200096206760174753****3153153453JOÃO MACEDO   BAR DO JOÃO  ";

    [Trait("Shared", "Cnab teste")]
    [Fact(DisplayName = nameof(Cnab_Obter_tipo_com_sucesso))]
    public void Cnab_Obter_tipo_com_sucesso()
    {
        //Arrange

        //Act
        var valor = linhaCnab.CnabObterTipo();

        //Assert
        Assert.Equal("3", valor);
    }

    [Trait("Shared", "Cnab teste")]
    [Fact(DisplayName = nameof(Cnab_Obter_valor_com_sucesso))]
    public void Cnab_Obter_valor_com_sucesso()
    {
        //Arrange

        //Act
        var valor = linhaCnab.CnabObterValor();

        //Assert
        Assert.Equal("0000014200", valor);
    }

    [Trait("Shared", "Cnab teste")]
    [Fact(DisplayName = nameof(Cnab_Obter_cpf_com_sucesso))]
    public void Cnab_Obter_cpf_com_sucesso()
    {
        //Arrange

        //Act
        var valor = linhaCnab.CnabObterCpf();

        //Assert
        Assert.Equal("09620676017", valor);
    }

    [Trait("Shared", "Cnab teste")]
    [Fact(DisplayName = nameof(Cnab_Obter_Cartao_com_sucesso))]
    public void Cnab_Obter_Cartao_com_sucesso()
    {
        //Arrange

        //Act
        var valor = linhaCnab.CnabObterCartao();

        //Assert
        Assert.Equal("4753****3153", valor);
    }

    [Trait("Shared", "Cnab teste")]
    [Fact(DisplayName = nameof(Cnab_Obter_Cartao_com_sucesso))]
    public void Cnab_Obter_nome_dono_loja_com_sucesso()
    {
        //Arrange

        //Act
        var valor = linhaCnab.CnabObterNomeDonoLoja();

        //Assert
        Assert.Equal("JOÃO MACEDO", valor);
    }

    [Trait("Shared", "Cnab teste")]
    [Fact(DisplayName = nameof(Cnab_Obter_nome_loja_com_sucesso))]
    public void Cnab_Obter_nome_loja_com_sucesso()
    {
        //Arrange

        //Act
        var valor = linhaCnab.CnabObterNomeLoja();

        //Assert
        Assert.Equal("BAR DO JOÃO", valor);
    }

    [Trait("Shared", "Cnab teste")]
    [Fact(DisplayName = nameof(Cnab_Obter_Data_com_sucesso))]
    public void Cnab_Obter_Data_com_sucesso()
    {
        //Arrange

        var data = new DateTimeOffset(2019, 3, 1, 15, 34, 53, TimeSpan.FromHours(-3));
        //Act
        var valor = linhaCnab.CnabObterData();

        //Assert
        Assert.Equal(data.LocalDateTime, valor.LocalDateTime);
    }
}