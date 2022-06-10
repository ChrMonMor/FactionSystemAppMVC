using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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
            Models.MapModel map = GetMapSize(1);
            ViewBag.Map = map;
            return View(map);
        }

        public Models.MapModel GetMapSize(int id)
        {
            Models.MapModel map = new Models.MapModel();
            string query = "select * From Maps where Id = "+id;
            try
            {
                using (SqlConnection con = new SqlConnection(Standards.Constring()))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        map = new Models.MapModel((int)rdr[0],
                                                  (int)rdr[1],
                                                  (int)rdr[2]);
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return map;
        }
    }
}
