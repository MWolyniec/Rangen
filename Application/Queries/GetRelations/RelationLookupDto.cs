using AutoMapper;
using Rangen.Application.Common.Mappings;
using Rangen.Application.Queries.Common;
using Rangen.Domain.Entities;

namespace Rangen.Application.Queries.GetRelations
{
    public class RelationLookupDto : ItemLookupDto, IMapFrom<Relation>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Relation, RelationLookupDto>();
        }
    }
}
