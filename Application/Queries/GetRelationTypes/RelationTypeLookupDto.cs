using AutoMapper;
using Rangen.Application.Common.Mappings;
using Rangen.Application.Queries.Common;
using Rangen.Domain.Entities;
using System.Collections.Generic;

namespace Rangen.Application.Queries.GetRelationTypes
{
    public class RelationTypeLookupDto : ItemLookupDto, IMapFrom<RelationType>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RelationType, RelationTypeLookupDto>();
        }
    }
}
