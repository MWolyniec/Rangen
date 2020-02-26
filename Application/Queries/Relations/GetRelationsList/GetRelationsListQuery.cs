using MediatR;
using Rangen.Application.Queries.Relations.Common;

namespace Rangen.Application.Queries.Relations.GetRelationsList
{
    public class GetRelationsListQuery : IRequest<ItemListVm<RelationDto>>
    {
    }
}
