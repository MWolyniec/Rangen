using Rangen.Application.Queries.Common;
using System.Collections.Generic;

namespace Rangen.Application.Queries.GetRelationTypesList
{
    public class RelationTypeDto : OccurrenceDto
    {



        public RelationTypeDto MirroredType { get; set; }
        public bool Transitive { get; set; }

        public List<OccurrenceDto> AllOccurrencesWithThisRelationType { get; set; }
    }
}
