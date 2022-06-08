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
            List<Models.AssetModel> viewAssetList = GetAllAssetsFromAssetTable();
            ViewBag.assetList = viewAssetList;
            return View();
        }
        //Get all the static assets from the database and returns a list
        public List<Models.AssetModel> GetAllAssetsFromAssetTable()
        {
            List<Models.AssetModel> assets = new List<Models.AssetModel>();
            string query = "select * From AssetTable";

            return assets.ToList();
        }
    }
}
