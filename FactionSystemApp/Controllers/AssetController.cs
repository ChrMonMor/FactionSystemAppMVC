using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

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
            return View(viewAssetList);
        }

        public IActionResult Details(int id)
        {
            Models.AssetModel assetDetail = new();
            return View("Details", assetDetail);
        }

        //Get all the static assets from the database and returns a list
        public List<Models.AssetModel> GetAllAssetsFromAssetTable()
        {
            List<Models.AssetModel> assets = new();
            string query = "select * From AssetTable";
            using (SqlConnection connection =
            new SqlConnection(Standards.Constring()))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(query, connection);

                // Create and execute the DataReader..
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i <= reader.FieldCount - 1; i++) 
                    {
                    }

                }
            }
            return assets.ToList();
        }
    }
}
