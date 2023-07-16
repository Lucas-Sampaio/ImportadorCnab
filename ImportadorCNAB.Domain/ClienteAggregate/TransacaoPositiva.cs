namespace ImportadorCNAB.Domain.ClienteAggregate;

public class TransacaoPositiva : TipoTransacao
{
    public TransacaoPositiva(int codigo, string descricao) : base(codigo, descricao)
    {
        this.Natureza = Shared.Enums.ENatureza.Entrada;
    }
}