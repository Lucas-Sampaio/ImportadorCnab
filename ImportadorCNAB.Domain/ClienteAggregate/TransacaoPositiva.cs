namespace ImportadorCNAB.Domain.ClienteAggregate;

public class TransacaoPositiva : TipoTransacao
{
    /// <summary>
    /// Constroi um objeto TransacaoPositiva
    /// </summary>
    /// <param name="codigo"> codigo</param>
    /// <param name="descricao">descricao </param>
    /// <param name="id">Opcional - permite criar com o valor id inicial</param>
    public TransacaoPositiva(int codigo, string descricao, int id = 0) : base(codigo, descricao)
    {
        this.Natureza = Shared.Enums.ENatureza.Entrada;
        this.Id = id;
    }
}