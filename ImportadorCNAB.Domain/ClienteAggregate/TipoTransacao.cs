using ImportadorCNAB.Domain.seedWork;
using ImportadorCNAB.Domain.Shared.Enums;

namespace ImportadorCNAB.Domain.ClienteAggregate;

public abstract class TipoTransacao : Entity
{
    protected TipoTransacao()
    { }

    protected TipoTransacao(int codigo, string descricao)
    {
        Codigo = codigo;
        Descricao = descricao;
    }

    public int Codigo { get; init; }
    public string Descricao { get; init; }
    public ENatureza Natureza { get; protected set; }
}