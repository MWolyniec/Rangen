using MediatR;
using Rangen.Application.Queries.Relations.Common;

namespace Rangen.Application.Queries.Relations.GetGenericOccurrencesList
{
    public class GetSpecificOccurrencesListQuery : IRequest<ItemListVm<SpecificOccurrenceDto>>
    {
    }
}
