using Rangen.Domain.Common;

namespace Rangen.Domain.Entities
{


    public class GenericOccurrence : Occurrence
    {
        public float GeneralChanceToOccur { get; set; }


        public GenericOccurrence(string name) : base(name)
        {
        }

    }
}
