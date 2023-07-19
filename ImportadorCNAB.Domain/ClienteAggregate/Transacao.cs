using ImportadorCNAB.Domain.seedWork;

namespace ImportadorCNAB.Domain.ClienteAggregate;

public class Transacao : Entity
{
    protected Transacao()
    { }

    public Transacao(DateTimeOffset data, decimal valor, string cartaoUtilizado, TipoTransacao tipoTransacao)
    {
        Data = data;
        Valor = valor;
        CartaoUtilizadoNumero = cartaoUtilizado;
        TipoTransacao = tipoTransacao;
    }

    public DateTimeOffset Data { get; init; }
    public decimal Valor { get; init; }
    public string CartaoUtilizadoNumero { get; init; }
    public TipoTransacao TipoTransacao { get; init; }
}