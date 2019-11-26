using System.Collections.Generic;

namespace Rangen.Entities.POCO
{
    public class CategoryType : Item
    {
        public CategoryType(string name, string description) : base(name, description) { }
        public CategoryType(string name, string description, ICollection<Category> categories) : base(name, description)
        {
            Categories = categories;
        }
        public int Id { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}