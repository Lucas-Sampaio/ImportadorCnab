using ImportadorCNAB.Web.Models;
using ImportadorCNAB.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImportadorCNAB.Web.Pages
{
    public class VisualizarClienteModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IClienteService _clienteService;
        public ClienteVM Cliente { get; set; }

        public VisualizarClienteModel(IClienteService clienteService, ILogger<IndexModel> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var result = await _clienteService.ObterCliente(id);
            if (!string.IsNullOrWhiteSpace(result.erro))
            {
                _logger.LogError(result.erro);
            }

            Cliente = result.cliente;
            return Page();
        }
    }
}