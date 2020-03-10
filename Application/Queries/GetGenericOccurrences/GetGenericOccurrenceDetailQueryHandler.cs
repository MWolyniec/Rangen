using AutoMapper;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.Common;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.GetGenericOccurrences
{
    public class GetGenericOccurrenceDetailQueryHandler
        : GetItemDetailQueryHandler<GetGenericOccurrenceDetailQuery, GenericOccurrenceDetailVm, GenericOccurrence>
    {
        public GetGenericOccurrenceDetailQueryHandler(IRangenDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<GenericOccurrenceDetailVm> Handle(GetGenericOccurrenceDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.GenericOccurrences
                .FindAsync(request.Id);


            return Handle_Base(entity, request);
        }
    }
}
