using Rangen.Application.Queries.Relations.Common;
using Rangen.Application.Queries.Relations.GetRelationTypesList;

namespace Rangen.Application.Queries.Relations.GetRelationsList
{
    public class RelationDto : ItemDto
    {
        public OccurrenceDto Occurrence1 { get; set; }
        public float Occurrence1ChanceToOccurInRelation { get; set; }

        public OccurrenceDto Occurrence2 { get; set; }
        public float Occurrence2ChanceToOccurInRelation { get; set; }


        public RelationTypeDto RelationType { get; set; }
    }
}
