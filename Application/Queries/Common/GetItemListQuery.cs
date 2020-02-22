using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rangen.Application.Queries.Common
{
    public class GetItemListQuery<TDto> : IRequest<ItemListVm<TDto>> where TDto : ItemDto
    {
    }
}
