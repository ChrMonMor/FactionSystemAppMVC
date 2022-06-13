using FactionSystemApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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

        public IActionResult CreateNewFaction()
        {
            List<FactionModel> viewFactionList = GetAllFactionsFromList();
            ViewBag.factionList = viewFactionList;
            return View(viewFactionList);
        }

        private List<FactionModel> GetAllFactionsFromList()
        {
            List<FactionModel> factions = new();
            string query = "select * From Factions";
            try
            {
                using (SqlConnection con = new SqlConnection(Standards.Constring()))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        factions.Add(new FactionModel(Convert.ToInt32(rdr[0]),
                                                      rdr[1].ToString(),
                                                      (int)rdr[2],
                                                      (int)rdr[3],
                                                      (int)rdr[4],
                                                      (int)rdr[5],
                                                      (int)rdr[6],
                                                      new List<AssetModel>(),
                                                      new AssetModel(),
                                                      rdr[8].ToString()));
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return factions;
        }

        public IActionResult Tags()
        {
            List<TagModel> viewTagList = GetAllTagsFromTagTable();
            ViewBag.tagList = viewTagList;
            return View(viewTagList);
        }

        public IActionResult TagDetails(int id) 
        {
            TagModel viewTagDetails = GetTagsDetail(id);
            ViewBag.tagDetails = viewTagDetails;
            return View("TagDetails", viewTagDetails);
        }

        private TagModel GetTagsDetail(int id)
        {
            TagModel tagDetail = new();
            string query = "select * From TagTable where Id = " + id;
            try
            {
                using (SqlConnection con = new SqlConnection(Standards.Constring()))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        tagDetail = new TagModel(Convert.ToInt32(rdr[0]),
                                                            rdr[1].ToString(),
                                                            rdr[2].ToString(),
                                                            rdr[3].ToString());
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tagDetail;
        }

        public List<TagModel> GetAllTagsFromTagTable()
        {
            List<TagModel> tags = new();
            string query = "select * From TagTable";
            try
            {
                using (SqlConnection con = new SqlConnection(Standards.Constring()))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        tags.Add(new TagModel(Convert.ToInt32(rdr[0]),
                                                         rdr[1].ToString(),
                                                         rdr[2].ToString(),
                                                         rdr[3].ToString()));
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tags;
        }
    }
}
