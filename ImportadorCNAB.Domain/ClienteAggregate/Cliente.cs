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
        _transacoes = new List<Transacao>();
    }

    public string NomeLoja { get; }
    public string Nome { get; }
    public CPF Cpf { get; }
    private readonly List<Transacao> _transacoes;
    public IReadOnlyCollection<Transacao> Transacoes => _transacoes;

    public void AdicionarTransacao(Transacao transacao)
    {
        _transacoes.Add(transacao);
    }

    public void AdicionarTransacoes(IEnumerable<Transacao> transacoes)
    {
        _transacoes.AddRange(transacoes);
    }
}