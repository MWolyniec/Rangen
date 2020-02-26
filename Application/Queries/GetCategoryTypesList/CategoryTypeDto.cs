using Rangen.Application.Queries.Relations.Common;
using Rangen.Application.Queries.Relations.GetCategoriesList;
using System.Collections.Generic;

namespace Rangen.Application.Queries.Relations.GetCategoryTypesList
{
    public class CategoryTypeDto : ItemDto
    {
        public ICollection<CategoryDto> Categories { get; set; }
    }
}
