using MediatR;
using Rangen.Application.Queries.Common;

namespace Rangen.Application.Queries.GetGenericOccurrencesList
{
    public class GetGenericOccurrencesListQuery : IRequest<ItemListVm<GenericOccurrenceDto>>
    {
    }
}
