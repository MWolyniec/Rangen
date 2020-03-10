using MediatR;
using Rangen.Application.Queries.Common;

namespace Rangen.Application.Queries.GetCategories
{
    public class GetCategoriesListQuery : GetItemListQuery<CategoryLookupDto>
    {
    }
}
