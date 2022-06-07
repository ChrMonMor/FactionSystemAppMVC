using Microsoft.AspNetCore.Mvc;

namespace FactionSystemApp.Controllers
{
    public class MapController : Controller
    {
        private readonly ILogger<MapController> _logger;

        public MapController(ILogger<MapController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
