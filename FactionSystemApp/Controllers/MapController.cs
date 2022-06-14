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

        public static List<Models.PlanetModel> GetAllPlanetsInMap(int id)
        {
            List<Models.PlanetModel> planets = new List<Models.PlanetModel>();
            string query = "select * From Planet where Map = " + id +" Order by X asc, Y asc";
            try
            {
                using (SqlConnection con = new SqlConnection(Standards.Constring()))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        planets.Add(new Models.PlanetModel((int)rdr[0],
                                                  rdr[1].ToString(),
                                                  rdr[2].ToString(),
                                                  (int)rdr[3],
                                                  (int)rdr[4],
                                                  (int)rdr[5]));
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return planets;
        }
    }
}
