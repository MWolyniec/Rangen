using Rangen.Domain.Common;
using System.Collections.Generic;

namespace Rangen.Domain.Entities
{
    public class CategoryType : Occurrence
    {
        public ICollection<Category> Categories { get; set; }


        public CategoryType(string name) : base(name)
        {
        }

    }
}