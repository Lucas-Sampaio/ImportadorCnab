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
}