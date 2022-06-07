using Microsoft.AspNetCore.Mvc;

namespace FactionSystemApp.Controllers
{
    public class FactionController : Controller
    {
        private readonly ILogger<FactionController> _logger;

        public FactionController(ILogger<FactionController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
