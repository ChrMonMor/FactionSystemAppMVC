namespace FactionSystemApp.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Tag Name";
        public string Description { get; set; } = "Tag Description";
        public string Effect { get; set; } = "Tag Effect";

        public TagModel() { }
        public TagModel(int id, string name, string description, string effect)
        {
            Id = id;
            Name = name;
            Description = description;
            Effect = effect;
        }
    }
}
