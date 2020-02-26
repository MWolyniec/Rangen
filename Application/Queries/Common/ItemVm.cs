using System;
using System.Collections.Generic;
using System.Text;

namespace Rangen.Application.Queries.Relations.Common
{
    public class ItemListVm<TDto> where TDto : ItemDto
    {
        public IList<TDto> Items { get; set; }

        public int Count { get; set; }
    }
}
