using System.Collections.Generic;

namespace Rangen.Entities.POCO
{
    public class Category : Item
    {

        public Category(string name, string description) : base(name, description) { }
        public Category(string name, string description, CategoryType type, ICollection<Brick> bricks) : base(name, description)
        {
            Type = type;
            Bricks = bricks;
        }
        public int Id { get; set; }
        public CategoryType Type { get; set; }
        public ICollection<Brick> Bricks { get; set; }
    }
}
