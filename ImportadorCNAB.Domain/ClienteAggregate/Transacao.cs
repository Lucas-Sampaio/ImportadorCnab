using ImportadorCNAB.Domain.Shared.Enums;

namespace ImportadorCNAB.Domain.ClienteAggregate;

public class Transacao
{
    protected Transacao()
    { }

    public Transacao(DateTimeOffset data, decimal valor, string cartaoUtilizado, ETipoTransacao tipoTransacao)
    {
        Data = data;
        Valor = valor;
        CartaoUtilizadoNumero = cartaoUtilizado;
        TipoTransacao = tipoTransacao;
    }

    public DateTimeOffset Data { get; init; }
    public decimal Valor { get; init; }
    public string CartaoUtilizadoNumero { get; init; }
    public ETipoTransacao TipoTransacao { get; init; }
}