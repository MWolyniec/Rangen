using AutoMapper;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.GetCategoryTypesList
{
    public class GetCategoryTypesListQueryHandler : GetItemListQueryHandler<CategoryTypeLookupDto>
    {

        public GetCategoryTypesListQueryHandler(IRangenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<ItemListViewModel<CategoryTypeLookupDto>> Handle(GetItemListQuery<CategoryTypeLookupDto> request, CancellationToken cancellationToken)
        {
            var categoryTypes = base._context.CategoryTypes;
            return await base.ProjectDbSetToListAsync(categoryTypes, cancellationToken);
        }

    }
}

