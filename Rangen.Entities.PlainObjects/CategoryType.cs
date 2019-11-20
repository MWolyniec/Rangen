using System.Collections.Generic;

namespace Rangen.API.Core.Entities
{
    public class CategoryType : BaseItem
    {
        public int Id { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}