namespace ImportadorCNAB.Web.Services;

public class ImportadorCNABService : ServiceBase, IImportadorCNABService
{
    private readonly HttpClient _httpClient;

    public ImportadorCNABService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async ValueTask<(bool sucesso, string? erro)> ImportarArquivoCnab(IFormFile file)
    {
        using var content = new MultipartFormDataContent();
        var fileContent = new StreamContent(file.OpenReadStream());
        content.Add(fileContent, "file", file.FileName);

        var response = await _httpClient.PostAsync("api/ImportadorCnab", content);

        if (response.IsSuccessStatusCode)
        {
            // O arquivo foi enviado com sucesso para a API Web
            return (true, null);
        }
        else
        {
            var erro = await response.Content.ReadAsStringAsync();
            // Houve um erro ao enviar o arquivo para a API Web
            return (false, erro);
        }
    }
}