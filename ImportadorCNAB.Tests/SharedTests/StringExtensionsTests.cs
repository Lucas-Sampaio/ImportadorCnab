using ImportadorCNAB.Shared.Utils;
using Xunit;

namespace ImportadorCNAB.Tests.SharedTests;

public class StringExtensionsTests
{
    [Trait("Shared", "String extensions teste")]
    [Fact(DisplayName = nameof(Converter_string_para_inteiro_realizado_sucesso))]
    public void Converter_string_para_inteiro_realizado_sucesso()
    {
        //Arrange

        //Act
        var valor = "4".ToInt32();

        //Assert
        Assert.Equal(4, valor);
    }

    [Trait("Shared", "String extensions teste")]
    [Fact(DisplayName = nameof(Converter_string_para_inteiro_com_valor_default_realizado_sucesso))]
    public void Converter_string_para_inteiro_com_valor_default_realizado_sucesso()
    {
        //Arrange
        var valorDefault = 6;
        string? numString = null; 
        //Act
        var valor = numString.ToInt32(valorDefault);

        //Assert
        Assert.Equal(valorDefault, valor);
    }

    [Trait("Shared", "String extensions teste")]
    [Fact(DisplayName = nameof(Converter_string_para_decimal_realizado_sucesso))]
    public void Converter_string_para_decimal_realizado_sucesso()
    {
        //Arrange

        //Act
        var valor = "4,8".ToDecimal();

        //Assert
        Assert.Equal(4.8M, valor);
    }

    [Trait("Shared", "String extensions teste")]
    [Fact(DisplayName = nameof(Converter_string_para_decimal_com_valor_default_realizado_sucesso))]
    public void Converter_string_para_decimal_com_valor_default_realizado_sucesso()
    {
        //Arrange
        var valorDefault = 6.8M;
        string? numString = null;
        //Act
        var valor = numString.ToDecimal(valorDefault);

        //Assert
        Assert.Equal(valorDefault, valor);
    }
}