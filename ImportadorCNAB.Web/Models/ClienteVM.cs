namespace ImportadorCNAB.Web.Models;

public class ClienteVM
{
    public string NomeLoja { get; set; }
    public int Id { get; set; }
    public decimal SaldoTotal { get; set; }
    public List<TransacaoVM> Transacoes { get; set; }
}
