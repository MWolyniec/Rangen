using AutoMapper;
using Rangen.Application.Common.Mappings;
using Rangen.Application.Queries.Common;
using Rangen.Application.Queries.GetCategoryTypes;
using Rangen.Application.Queries.GetGenericOccurrences;
using Rangen.Domain.Entities;
using System.Collections.Generic;

namespace Rangen.Application.Queries.GetCategories
{
    public class CategoryDetailVm : ItemVm, IMapFrom<Category>
    {
        public CategoryTypeLookupDto CategoryType { get; set; }
        public ICollection<GenericOccurrenceLookupDto> GenericOccurrences { get; set; }



        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDetailVm>();
        }
    }
}
