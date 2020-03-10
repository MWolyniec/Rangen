using AutoMapper;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Common;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.GetRelations
{
    public class GetRelationDetailQueryHandler : GetItemDetailQueryHandler<GetRelationDetailQuery, RelationDetailVm, Relation>
    {
        public GetRelationDetailQueryHandler(IRangenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<RelationDetailVm> Handle(GetRelationDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Relations
                .FindAsync(request.Id);

            return Handle_Base(entity, request);
        }
    }
}
