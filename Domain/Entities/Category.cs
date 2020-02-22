using Rangen.Domain.Common;
using System.Collections.Generic;

namespace Rangen.Domain.Entities
{
    public class Category : Occurrence
    {


        public Category(string name) : base(name)
        {
            this.Name = name;
        }

        public CategoryType CategoryType { get; set; }
        public ICollection<GenericOccurrence> GenericOccurrences { get; set; }


    }
}
