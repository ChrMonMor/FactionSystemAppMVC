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
    }
}
