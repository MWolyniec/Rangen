using Rangen.Domain.Entities;
using System.Collections.Generic;

namespace Rangen.Domain.Common
{
    public abstract class Occurrence : Item
    {
        public List<Relation> Relations { get; set; }

        public Occurrence(string name) : base(name)
        {
            Relations = new List<Relation>();
        }
    }
}
