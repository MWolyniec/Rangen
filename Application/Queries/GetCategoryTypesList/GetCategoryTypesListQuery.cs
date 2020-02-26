using MediatR;
using Rangen.Application.Queries.Relations.Common;

namespace Rangen.Application.Queries.Relations.GetCategoryTypesList
{
    public class GetCategoryTypesListQuery : IRequest<ItemListVm<CategoryTypeDto>>
    {
    }
}
