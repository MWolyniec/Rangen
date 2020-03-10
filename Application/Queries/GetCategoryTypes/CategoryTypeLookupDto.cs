using AutoMapper;
using Rangen.Application.Common.Mappings;
using Rangen.Application.Queries.Common;
using Rangen.Domain.Entities;

namespace Rangen.Application.Queries.GetCategoryTypes
{
    public class CategoryTypeLookupDto : ItemLookupDto, IMapFrom<CategoryType>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryType, CategoryTypeLookupDto>();
        }
    }
}
