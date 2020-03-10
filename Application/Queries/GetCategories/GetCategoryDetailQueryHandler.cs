using AutoMapper;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Common;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.GetCategories
{
    public class GetCategoryDetailQueryHandler : GetItemDetailQueryHandler<GetCategoryDetailQuery, CategoryDetailVm, Category>
    {
        public GetCategoryDetailQueryHandler(IRangenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<CategoryDetailVm> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories
                .FindAsync(request.Id);

            return Handle_Base(entity, request);
        }
    }
}
