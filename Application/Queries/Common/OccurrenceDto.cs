using Rangen.Application.Queries.GetRelationsList;
using System.Collections.Generic;

namespace Rangen.Application.Queries.Common
{
    public class OccurrenceDto : ItemDto
    {

        public List<RelationDto> Relations { get; set; }

    }
}
