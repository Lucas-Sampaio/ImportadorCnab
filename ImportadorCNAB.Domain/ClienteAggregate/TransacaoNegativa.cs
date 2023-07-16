namespace ImportadorCNAB.Domain.ClienteAggregate;

public class TransacaoNegativa : TipoTransacao
{
    public TransacaoNegativa(int codigo, string descricao) : base(codigo, descricao)
    {
        this.Natureza = Shared.Enums.ENatureza.Saida;
    }
}