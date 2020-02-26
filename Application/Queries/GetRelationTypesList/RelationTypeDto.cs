using Rangen.Application.Queries.Relations.Common;
using System.Collections.Generic;

namespace Rangen.Application.Queries.Relations.GetRelationTypesList
{
    public class RelationTypeDto : OccurrenceDto
    {



        public RelationTypeDto MirroredType { get; set; }
        public bool Transitive { get; set; }

        public List<OccurrenceDto> AllOccurrencesWithThisRelationType { get; set; }
    }
}
