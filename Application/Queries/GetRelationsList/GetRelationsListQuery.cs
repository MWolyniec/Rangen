using MediatR;
using Rangen.Application.Queries.Common;

namespace Rangen.Application.Queries.GetRelationsList
{
    public class GetRelationsListQuery : IRequest<ItemListVm<RelationDto>>
    {
    }
}
