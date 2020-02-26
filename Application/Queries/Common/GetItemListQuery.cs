using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rangen.Application.Queries.Relations.Common
{
    public class GetItemListQuery<TDto> : IRequest<ItemListVm<TDto>> where TDto : ItemDto
    {
    }
}
