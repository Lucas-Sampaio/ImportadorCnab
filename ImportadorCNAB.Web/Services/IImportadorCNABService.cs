namespace ImportadorCNAB.Web.Services;

public interface IImportadorCNABService
{
    ValueTask<(bool sucesso, string? erro)> ImportarArquivoCnab(IFormFile file);
}
