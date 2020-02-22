using System.Collections.Generic;

namespace Rangen.Domain.Common
{
    public class Item
    {

        public Item(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
