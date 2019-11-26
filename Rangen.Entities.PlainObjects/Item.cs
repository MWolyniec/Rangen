namespace Rangen.Entities.POCO
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }

        public Item(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
