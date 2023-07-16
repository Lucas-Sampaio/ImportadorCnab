namespace ImportadorCNAB.Domain.ClienteAggregate;

public class TransacaoNegativa : TipoTransacao
{
    /// <summary>
    /// Constroi um objeto TransacaoNegativa
    /// </summary>
    /// <param name="codigo"> codigo</param>
    /// <param name="descricao">descricao </param>
    /// <param name="id">Opcional - permite criar com o valor id inicial</param>
    public TransacaoNegativa(int codigo, string descricao, int id = 0) : base(codigo, descricao)
    {
        this.Natureza = Shared.Enums.ENatureza.Saida;
        this.Id = id;
    }
}