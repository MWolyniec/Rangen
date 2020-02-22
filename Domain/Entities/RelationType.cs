
using Rangen.Domain.Common;

namespace Rangen.Domain.Entities
{
    public class RelationType : Item
    {
        public RelationType MirroredType { get; set; }
        public bool Transitive { get; set; }

        public RelationType(string name) : base(name)
        {

        }
    }
}