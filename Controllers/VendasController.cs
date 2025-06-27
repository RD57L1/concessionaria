using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProjetoFinal.Controllers
{
    [Route("[controller]")]
    public class VendasController : Controller
    {
        private readonly ILogger<VendasController> _logger;

        public VendasController(ILogger<VendasController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [NonAction] // Adicione esta linha
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    // Se ErrorViewModel não estiver definido no mesmo arquivo ou namespace, você pode precisar adicioná-lo
    // Ou adaptar o retorno para algo mais simples se não usar um ViewModel para o erro
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}