namespace FactionSystemApp.Models
{
    public class MapModel
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; } = "System Name";
        public string Description { get; set; } = "System Description";

        public MapModel() { }
        public MapModel(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
        public MapModel(int id, int x, int y, string name, string description)
        {
            Id = id;
            X = x;
            Y = y;
            Name = name;
            Description = description;
        }
    }
}
