namespace ImportadorCNAB.Shared.Utils;

public static class StreamReaderExtensions
{
    /// <summary>
    /// retorna linhas de um arquivo txt
    /// </summary>
    public static async ValueTask<IEnumerable<string>> ObterLinhasAsync(this StreamReader reader, CancellationToken cancellation)
    {
        string? line;
        var linhas = new List<string>();

        while ((line = await reader.ReadLineAsync(cancellation)) != null)
            linhas.Add(new string(line));

        return linhas;
    }
}