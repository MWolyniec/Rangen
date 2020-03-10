using AutoMapper;
using Rangen.Application.Common.Mappings;
using Rangen.Application.Queries.Common;
using Rangen.Application.Queries.GetCategories;
using Rangen.Domain.Entities;
using System.Collections.Generic;

namespace Rangen.Application.Queries.GetCategoryTypes
{
    public class CategoryTypeDetailVm : ItemVm, IMapFrom<CategoryType>
    {

        public ICollection<CategoryLookupDto> Categories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryType, CategoryTypeDetailVm>();
        }
    }
}
