namespace FactionSystemApp.Controllers
{
    public class Standards
    {
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
