using FactionSystemApp.Models;
using Microsoft.Data.SqlClient;

namespace FactionSystemApp.Controllers
{
    public class Standards
    {
        private static readonly string _conString = @"Data Source=MININT-MBLS0P9\SQLEXPRESS;Initial Catalog=FactionSystem;Integrated Security=True";

        public static string Constring()
        {
            return _conString;
        }
        public static int ClacFacHP(int cunning, int force, int wealth)
        {
            return ClacXpCost(cunning) + ClacXpCost(force) + ClacXpCost(wealth);
        }
        public static int ClacXpCost(int j)
        {
            int a = 1;
            int b = 0;
            int c = 0;
            for (int i = 1; i <= j; i++)
            {
                c += a;
                if (b == 2) { b = 0; a++; }
                b++;
            }
            return c;
        }
        public static List<AssetModel> GetAllAssetsFromAssetTableToNewFaction()
        {
            List<AssetModel> assets = new();
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
                        assets.Add(new AssetModel(Convert.ToInt32(rdr[0]),
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
