namespace ImportadorCNAB.Api.Application.Dtos;


public class TransacaoDto
{
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public string Cartao { get; set; }
    public string TipoTransacao { get; set; }
}