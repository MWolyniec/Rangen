using AutoMapper;
using Rangen.Application.Common.Mappings;
using Rangen.Application.Queries.Common;
using Rangen.Application.Queries.GetGenericOccurrences;
using Rangen.Application.Queries.GetRelations;
using Rangen.Domain.Entities;
using System.Collections.Generic;

namespace Rangen.Application.Queries.GetSpecificOccurrences
{
    public class SpecificOccurrenceDetailVm : ItemVm, IMapFrom<SpecificOccurrence>
    {

        public float RelativeAge { get; set; }
        public float RelativeSize { get; set; }

        public GenericOccurrenceLookupDto OccurrenceType { get; set; }

        public byte DryoutFactor { get; set; }

        public List<RelationLookupDto> Relations { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SpecificOccurrence, SpecificOccurrenceDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }

    }
}
