using Rangen.Application.Queries.Common;
using Rangen.Application.Queries.GetCategoryTypesList;
using Rangen.Application.Queries.GetGenericOccurrencesList;

namespace Rangen.Application.Queries.GetCategoriesList
{
    public class CategoryDto : OccurrenceDto
    {

        public CategoryTypeDto CategoryType { get; set; }

        public ItemListVm<GenericOccurrenceDto> GenericOccurrences { get; set; }
    }
}
