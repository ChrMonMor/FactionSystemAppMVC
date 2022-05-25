using FactionSystemApp.Controllers;

namespace FactionSystemApp.Models
{
    public class FactionModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Faction Name";
        public int ForceRating { get; set; }
        public int CunningRating { get; set; }
        public int WealthRating { get; set; }
        public int FacCred { get; set; }
        public int EXP { get; set; }
        public List<AssetModel> Assets { get; set; } = new List<AssetModel>();
        public AssetModel HQ { get; set; } = new AssetModel();
        public string Tag { get; set; } = string.Empty;

        // nothing and all
        public FactionModel() { }
        public FactionModel(int id, string name, int forceRating, int cunningRating, int wealthRating, int facCred, int eXP, List<AssetModel> assets, AssetModel hQ, string tag)
        {
            Id = id;
            Name = name;
            ForceRating = forceRating;
            CunningRating = cunningRating;
            WealthRating = wealthRating;
            FacCred = facCred;
            EXP = eXP;
            Assets = assets;
            HQ = hQ;
            Tag = tag;
        }
        // new Faction
        public FactionModel(string name, int forceRating, int cunningRating, int wealthRating, params AssetModel[] assets)
        {
            Name = name;
            ForceRating = forceRating;
            CunningRating = cunningRating;
            WealthRating = wealthRating;
            FacCred = wealthRating / 2 + forceRating / 4 + cunningRating / 4;
            EXP = 0;
            foreach (var item in assets)
            {
                Assets.Add(item);
            }
            HQ = new AssetModel() { HP = Standards.ClacFacHP(cunningRating, forceRating, wealthRating), Type = "Special" };
        }
    }
}
