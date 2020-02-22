using MediatR;
using Rangen.Application.Queries.Common;

namespace Rangen.Application.Queries.GetGenericOccurrencesList
{
    public class GetSpecificOccurrencesListQuery : IRequest<ItemListVm<SpecificOccurrenceDto>>
    {
    }
}
