using AutoMapper;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Common;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.GetRelationTypes
{
    public class GetRelationTypeDetailQueryHandler : GetItemDetailQueryHandler<GetRelationTypeDetailQuery, RelationTypeDetailVm, RelationType>
    {
        public GetRelationTypeDetailQueryHandler(IRangenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<RelationTypeDetailVm> Handle(GetRelationTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.RelationTypes
                .FindAsync(request.Id);

            return Handle_Base(entity, request);
        }
    }
}
