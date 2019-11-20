using System;
using System.Collections.Generic;
using System.Text;

namespace Rangen.API.Core.Entities
{
    public class Category : BaseItem
    {
        public int Id { get; set; }
        public CategoryType Type { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
