using MediatR;
using Rangen.Application.Queries.Common;

namespace Rangen.Application.Queries.Common
{
    public class GetItemListQuery<TLookupDto> : IRequest<ItemListViewModel<TLookupDto>>
    {
    }
}
