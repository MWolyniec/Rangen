using AutoMapper;
using Rangen.Application.Common.Mappings;
using Rangen.Application.Queries.Common;
using Rangen.Domain.Entities;

namespace Rangen.Application.Queries.GetSpecificOccurrences
{
    public class SpecificOccurrenceLookupDto : ItemLookupDto, IMapFrom<SpecificOccurrence>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SpecificOccurrence, SpecificOccurrenceLookupDto>();
        }
    }
}
