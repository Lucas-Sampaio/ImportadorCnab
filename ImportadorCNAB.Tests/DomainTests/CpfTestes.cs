using ImportadorCNAB.Domain.ClienteAggregate;
using ImportadorCNAB.Domain.Exceptions;
using Xunit;

namespace ImportadorCNAB.Tests.DomainTests;

public class CpfTestes
{
    [Trait("Domain", "Cpf teste")]
    [Fact(DisplayName = nameof(Cpf_Valido_RetornaTrue))]
    public void Cpf_Valido_RetornaTrue()
    {
        //Arrange
        var cpf1 = "961.232.190-65"; //valido
        var cpf2 = "96123219065"; //valido

        //Act
        var result1 = CPF.Validar(cpf1);
        var result2 = CPF.Validar(cpf2);
        var result3 = new CPF(cpf2);

        //Assert
        Assert.True(result1);
        Assert.True(result2);
        Assert.NotNull(result3);
    }

    [Trait("Domain", "Cpf teste")]
    [Fact(DisplayName = nameof(Cpf_Invalido_RetornaException))]
    public void Cpf_Invalido_RetornaException()
    {
        //Arrange

        var cpf3 = "961.252.190-45";//invalido

        //Act

        //Assert
        Assert.Throws<DomainException>(() => new CPF(cpf3));
    }

    [Trait("Domain", "Cpf teste")]
    [Fact(DisplayName = nameof(Cpf_Invalido_RetornaFalse))]
    public void Cpf_Invalido_RetornaFalse()
    {
        //Arrange

        var cpf3 = "961.252.190-45";//invalido

        //Act
        var result1 = CPF.Validar(cpf3);

        //Assert
        Assert.False(result1);
    }
}