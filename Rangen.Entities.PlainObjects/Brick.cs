using System.Collections.Generic;

namespace Rangen.Entities.POCO
{
    public class Brick : Item
    {

        public Brick(string name, string description, ICollection<Category> categories, ICollection<Brick> parents, ICollection<Brick> children) : base(name, description)
        {
            Categories = categories;
            Parents = parents;
            Children = children;
        }
        public Brick(string name, string description) : base(name, description)
        {
        }

        public long Id { get; }

        public ICollection<Category> Categories { get; set; }
        public ICollection<Brick> Parents { get; set; }
        public ICollection<Brick> Children { get; set; }
    }
}
