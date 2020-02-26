using MediatR;
using Rangen.Application.Queries.Relations.Common;

namespace Rangen.Application.Queries.Relations.GetRelationTypesList
{
    public class GetRelationTypesListQuery : IRequest<ItemListVm<RelationTypeDto>>
    {
    }
}
