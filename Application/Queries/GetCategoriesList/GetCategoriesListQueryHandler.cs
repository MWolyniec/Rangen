using AutoMapper;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : GetItemListQueryHandler<CategoryDto>
    {

        public GetCategoriesListQueryHandler(IRangenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<ItemListVm<CategoryDto>> Handle(GetItemListQuery<CategoryDto> request, CancellationToken cancellationToken)
        {
            var categories = base._context.Categories;
            return await base.ProjectDbSetToListAsync(categories, cancellationToken);
        }

    }
}
