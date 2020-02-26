using AutoMapper;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Relations.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.Relations.GetCategoryTypesList
{
    public class GetCategoryTypesListQueryHandler : GetItemListQueryHandler<CategoryTypeDto>
    {

        public GetCategoryTypesListQueryHandler(IRangenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<ItemListVm<CategoryTypeDto>> Handle(GetItemListQuery<CategoryTypeDto> request, CancellationToken cancellationToken)
        {
            var categoryTypes = base._context.CategoryTypes;
            return await base.ProjectDbSetToListAsync(categoryTypes, cancellationToken);
        }

    }
}

