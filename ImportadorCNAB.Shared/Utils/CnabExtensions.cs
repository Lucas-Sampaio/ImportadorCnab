namespace ImportadorCNAB.Shared.Utils;

public static class CnabExtensions
{
    /// <summary>
    /// retorna o Tipo da transação
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    public static string CnabObterTipo(this string valor)
    {
        return valor[..1];
    }

    /// <summary>
    /// retorna o Tipo da transação
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    public static DateTimeOffset CnabObterData(this string valor)
    {
        var dataString = valor[1..9];
        var ano = dataString[..4].ToInt32();
        var mes = dataString[4..6].ToInt32();
        var dia = dataString[6..8].ToInt32();

        var horaString = valor[42..48];
        var hora = horaString[..2].ToInt32();
        var minuto = horaString[2..4].ToInt32();
        var segundos = horaString[4..6].ToInt32();

        var data = new DateTimeOffset(ano, mes, dia, hora, minuto, segundos, TimeSpan.FromHours(-3));
        return data;
    }

    /// <summary>
    /// retorna o Tipo da transação
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    public static string CnabObterValor(this string valor)
    {
        return valor[9..19].Trim();
    }

    /// <summary>
    /// retorna o Tipo da transação
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    public static string CnabObterCpf(this string valor)
    {
        return valor[19..30].Trim();
    }

    /// <summary>
    /// retorna o Tipo da transação
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    public static string CnabObterCartao(this string valor)
    {
        return valor[30..42].Trim();
    }

    /// <summary>
    /// retorna o Tipo da transação
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    public static string CnabObterHora(this string valor)
    {
        return valor[42..48].Trim();
    }

    /// <summary>
    /// retorna o Tipo da transação
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    public static string CnabObterNomeDonoLoja(this string valor)
    {
        return valor[48..62].Trim();
    }

    /// <summary>
    /// retorna o Tipo da transação
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    public static string CnabObterNomeLoja(this string valor)
    {
        return valor[62..80].Trim();
    }
}