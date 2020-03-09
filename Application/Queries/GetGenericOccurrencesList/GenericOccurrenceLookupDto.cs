using AutoMapper;
using Rangen.Application.Common.Mappings;
using Rangen.Application.Queries.Common;
using Rangen.Domain.Entities;

namespace Rangen.Application.Queries.GetGenericOccurrences
{
    public class GenericOccurrenceLookupDto : ItemLookupDto, IMapFrom<GenericOccurrence>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GenericOccurrence, GenericOccurrenceLookupDto>();
        }

    }
}
