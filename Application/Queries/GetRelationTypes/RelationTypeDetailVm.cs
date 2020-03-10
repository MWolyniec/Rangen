using AutoMapper;
using Rangen.Application.Common.Mappings;
using Rangen.Application.Queries.Common;
using Rangen.Domain.Entities;

namespace Rangen.Application.Queries.GetRelationTypes
{
    public class RelationTypeDetailVm : ItemVm, IMapFrom<RelationType>
    {
        public RelationTypeLookupDto MirroredType { get; set; }
        public bool Transitive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RelationType, RelationTypeDetailVm>();
        }
    }
}
