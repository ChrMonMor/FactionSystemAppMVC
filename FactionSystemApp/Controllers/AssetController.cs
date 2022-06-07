using Microsoft.AspNetCore.Mvc;

namespace FactionSystemApp.Controllers
{
    public class AssetController : Controller
    {
        private readonly ILogger<AssetController> _logger;

        public AssetController(ILogger<AssetController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
