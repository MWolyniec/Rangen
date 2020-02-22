using Rangen.Application.Queries.Common;
using Rangen.Application.Queries.GetCategoriesList;
using System.Collections.Generic;

namespace Rangen.Application.Queries.GetCategoryTypesList
{
    public class CategoryTypeDto : ItemDto
    {
        public ICollection<CategoryDto> Categories { get; set; }
    }
}
