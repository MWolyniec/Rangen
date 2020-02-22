using MediatR;
using Rangen.Application.Queries.Common;

namespace Rangen.Application.Queries.GetRelationTypesList
{
    public class GetRelationTypesListQuery : IRequest<ItemListVm<RelationTypeDto>>
    {
    }
}
