using MediatR;
using Rangen.Application.Queries.Common;

namespace Rangen.Application.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : GetItemListQuery<CategoryLookupDto>
    {
    }
}
