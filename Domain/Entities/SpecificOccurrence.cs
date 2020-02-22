using Rangen.Domain.Common;
using System.Collections.Generic;

namespace Rangen.Domain.Entities
{
    public class SpecificOccurrence : Occurrence
    {
        public SpecificOccurrence(string name) : base(name)
        {
        }

        public float RelativeAge { get; set; }
        public float RelativeSize { get; set; }

        public GenericOccurrence OccurrenceType { get; set; }

        public byte DryoutFactor { get; set; }

        public ICollection<Relation> GenericRelations { get; set; }



    }
}
