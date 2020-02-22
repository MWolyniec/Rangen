using Rangen.Application.Queries.Common;
using Rangen.Application.Queries.GetRelationsList;
using System.Collections.Generic;

namespace Rangen.Application.Queries.GetGenericOccurrencesList
{
    public class SpecificOccurrenceDto : ItemDto
    {


        public float RelativeAge { get; set; }
        public float RelativeSize { get; set; }

        public GenericOccurrenceDto OccurrenceType { get; set; }

        public byte DryoutFactor { get; set; }

        public List<RelationDto> GenericRelations { get; set; }
    }
}
