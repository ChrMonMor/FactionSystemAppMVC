namespace FactionSystemApp.Models
{
    public class AssetModel
    {
        public int Id { get; set; }
        public char Category { get; set; }
        public string Name { get; set; } = "Asset Name";
        public string Description { get; set; } = "Asset Description";
        public int HP { get; set; }
        public int Cost { get; set; }
        public int TechLevel { get; set; }
        public string Type { get; set; } = "None";
        public string Attack { get; set; } = "None";
        public string Counterattack { get; set; } = "None";
        public string Special { get; set; } = "None";
        public PlanetModel Location { get; set; } = new PlanetModel();

        // nothing and all
        public AssetModel() { }
        public AssetModel(int id, char category, string name, string description, int hP, int cost, int techLevel, string type, string attack, string counterattack, string special, PlanetModel location)
        {
            Id = id;
            Category = category;
            Name = name;
            Description = description;
            HP = hP;
            Cost = cost;
            TechLevel = techLevel;
            Type = type;
            Attack = attack;
            Counterattack = counterattack;
            Special = special;
            Location = location;
        }

    }
}
