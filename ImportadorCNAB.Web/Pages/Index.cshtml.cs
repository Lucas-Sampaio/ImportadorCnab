using ImportadorCNAB.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImportadorCNAB.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IImportadorCNABService _importador;
    public bool ShowSuccessMessage { get; set; }
    public string? MensagemErro { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IImportadorCNABService importador)
    {
        _logger = logger;
        _importador = importador;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(IFormFile fileInput)
    {
        if (fileInput is null || fileInput.Length == 0)
        {
            ShowSuccessMessage = false;
            MensagemErro = "Arquivo invalido";
            return Page();
        }

        var result = await _importador.ImportarArquivoCnab(fileInput);
        if (result.sucesso)
        {
            ShowSuccessMessage = true;
            return Page();
        }
        else
        {
            _logger.LogError(result.erro);
            ShowSuccessMessage = false;
            MensagemErro = "Ocoreu um erro na hora de importar o arquivo";
            return Page();
        }
    }
}