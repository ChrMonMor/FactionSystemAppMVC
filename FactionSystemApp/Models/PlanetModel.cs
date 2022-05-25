namespace FactionSystemApp.Models
{
    public class PlanetModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Planet Name";
        public string Description { get; set; } = "Planet Description";
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; } = 0;

        // nothing and all
        public PlanetModel() { }
        public PlanetModel(int id, string name, string description, int x, int y, int z)
        {
            Id = id;
            Name = name;
            Description = description;
            X = x;
            Y = y;
            Z = z;
        }
    }
}
