using MediatR;
using Rangen.Application.Queries.Relations.Common;

namespace Rangen.Application.Queries.Relations.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<ItemListVm<CategoryDto>>
    {
    }
}
