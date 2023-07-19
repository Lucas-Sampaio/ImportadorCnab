namespace ImportadorCNAB.Api.Application.Dtos;

public class ClienteDto
{
    public string NomeLoja { get; set; }
    public int Id { get; set; }
    public decimal SaldoTotal { get; set; }
    public List<TransacaoDto> Transacoes { get; set; }
}