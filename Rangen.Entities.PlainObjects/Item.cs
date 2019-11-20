using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rangen.API.Core.Entities
{
    public class Item : BaseItem
    {
        private object name;
        private object description;

        public Item(object name, object description)
        {
            this.name = name;
            this.description = description;
        }

        public long Id { get; set; }
        public ICollection<Item> Parents { get; set; }
        public ICollection<Item> Children { get; set; }
    }
}
