using Rangen.Application.Queries.Relations.Common;
using Rangen.Application.Queries.Relations.GetCategoryTypesList;
using Rangen.Application.Queries.Relations.GetGenericOccurrencesList;

namespace Rangen.Application.Queries.Relations.GetCategoriesList
{
    public class CategoryDto : OccurrenceDto
    {

        public CategoryTypeDto CategoryType { get; set; }

        public ItemListVm<GenericOccurrenceDto> GenericOccurrences { get; set; }
    }
}
