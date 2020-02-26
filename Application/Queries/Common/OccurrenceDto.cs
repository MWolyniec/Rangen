using Rangen.Application.Queries.Relations.GetRelationsList;
using System.Collections.Generic;

namespace Rangen.Application.Queries.Relations.Common
{
    public class OccurrenceDto : ItemDto
    {

        public List<RelationDto> Relations { get; set; }

    }
}
