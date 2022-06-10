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
            string query = "select * From AssetTable where Id = " + id;
            try
            {
                using (SqlConnection con = new SqlConnection(Standards.Constring()))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        assetDetail = new Models.AssetModel(Convert.ToInt32(rdr[0]),
                                                            rdr[1].ToString(),
                                                            rdr[2].ToString(),
                                                            rdr[3].ToString(),
                                                            (int)rdr[4],
                                                            Convert.ToInt32(rdr[5]),
                                                            Convert.ToInt32(rdr[6]),
                                                            rdr[7].ToString(),
                                                            rdr[8].ToString(),
                                                            rdr[9].ToString(),
                                                            rdr[10].ToString());
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View("Details", assetDetail);
        }

        //Get all the static assets from the database and returns a list
        public List<Models.AssetModel> GetAllAssetsFromAssetTable()
        {
            List<Models.AssetModel> assets = new();
            string query = "select * From AssetTable";
            try
            {
                using (SqlConnection con = new SqlConnection(Standards.Constring()))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        assets.Add(new Models.AssetModel(Convert.ToInt32(rdr[0]),
                                                         rdr[1].ToString(),
                                                         rdr[2].ToString(),
                                                         rdr[3].ToString(),
                                                         (int)rdr[4],
                                                         Convert.ToInt32(rdr[5]),
                                                         Convert.ToInt32(rdr[6]),
                                                         rdr[7].ToString(),
                                                         rdr[8].ToString(),
                                                         rdr[9].ToString(),
                                                         rdr[10].ToString()));
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return assets;
        }
    }
}
