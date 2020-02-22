using MediatR;
using Rangen.Application.Queries.Common;

namespace Rangen.Application.Queries.GetCategoryTypesList
{
    public class GetCategoryTypesListQuery : IRequest<ItemListVm<CategoryTypeDto>>
    {
    }
}
