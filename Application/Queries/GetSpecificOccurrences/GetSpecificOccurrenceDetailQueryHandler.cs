using AutoMapper;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Common;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.GetSpecificOccurrences
{
    public class GetSpecificOccurrenceDetailQueryHandler
        : GetItemDetailQueryHandler<GetSpecificOccurrenceDetailQuery, SpecificOccurrenceDetailVm, SpecificOccurrence>
    {
        public GetSpecificOccurrenceDetailQueryHandler(IRangenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<SpecificOccurrenceDetailVm> Handle(GetSpecificOccurrenceDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SpecificOccurrences
                .FindAsync(request.Id);

            return Handle_Base(entity, request);
        }
    }

}
