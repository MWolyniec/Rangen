using Rangen.Domain.Entities;
using System.Collections.Generic;

namespace Rangen.Domain.Common
{
    public abstract class Occurrence : Item
    {
        public ICollection<Relation> RelationsAsOccurrence1 { get; set; }
        public ICollection<Relation> RelationsAsOccurrence2 { get; set; }

        public Occurrence(string name) : base(name)
        {
            RelationsAsOccurrence2 = new List<Relation>();
            RelationsAsOccurrence1 = new List<Relation>();
        }
    }
}
