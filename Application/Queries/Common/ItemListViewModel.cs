using System.Collections.Generic;

namespace Rangen.Application.Queries.Common
{
    public class ItemListViewModel<TLookupDto>
    {
        public IList<TLookupDto> Items { get; set; }

        public int Count { get; set; }
    }
}
