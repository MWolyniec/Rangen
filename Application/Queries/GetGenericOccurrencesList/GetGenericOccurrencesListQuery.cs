using MediatR;
using Rangen.Application.Queries.Relations.Common;

namespace Rangen.Application.Queries.Relations.GetGenericOccurrencesList
{
    public class GetGenericOccurrencesListQuery : IRequest<ItemListVm<GenericOccurrenceDto>>
    {
    }
}
