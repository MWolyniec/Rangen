

using Rangen.Domain.Common;

namespace Rangen.Domain.Entities
{
    public class Relation : Item
    {

        public Occurrence Occurrence1 { get; set; }
        public int Occurrence1Id { get; set; }

        public Occurrence Occurrence2 { get; set; }
        public int Occurrence2Id { get; set; }

        public RelationType RelationType { get; set; }

        public float Occurrence1ChanceToOccurInTheRelation { get; set; }
        public float Occurrence2ChanceToOccurInTheRelation { get; set; }


        public Relation(string name) : base(name)
        {
        }
    }
}
