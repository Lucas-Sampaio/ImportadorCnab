using ImportadorCNAB.Domain.seedWork;

namespace ImportadorCNAB.Domain.ClienteAggregate;

public class Cliente : Entity, IAggregateRoot
{
    protected Cliente()
    {
    }

    public Cliente(string nomeLoja, string nome, CPF cpf)
    {
        NomeLoja = nomeLoja;
        Nome = nome;
        Cpf = cpf;
    }

    public string NomeLoja { get; private set; }
    public string Nome { get; private set; }
    public CPF Cpf { get; private set; }
    public List<Transacao> Transacoes { get; set; }
}