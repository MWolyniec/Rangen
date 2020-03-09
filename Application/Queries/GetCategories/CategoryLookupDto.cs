using AutoMapper;
using Rangen.Application.Common.Mappings;
using Rangen.Application.Queries.Common;
using Rangen.Domain.Entities;

namespace Rangen.Application.Queries.GetCategoriesList
{
    public class CategoryLookupDto : ItemLookupDto, IMapFrom<Category>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryLookupDto>();
        }
    }
}
