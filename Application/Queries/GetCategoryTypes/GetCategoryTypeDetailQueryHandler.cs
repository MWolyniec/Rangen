using AutoMapper;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Common;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.GetCategoryTypes
{
    public class GetCategoryTypeDetailQueryHandler : GetItemDetailQueryHandler<GetCategoryTypeDetailQuery, CategoryTypeDetailVm, CategoryType>
    {
        public GetCategoryTypeDetailQueryHandler(IRangenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<CategoryTypeDetailVm> Handle(GetCategoryTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.CategoryTypes
                .FindAsync(request.Id);

            return Handle_Base(entity, request);
        }
    }
}
