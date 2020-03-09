using AutoMapper;
using MediatR;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Queries.GetSpecificOccurrences
{
    public class GetSpecificOccurrenceDetailQueryHandler : IRequestHandler<GetSpecificOccurrenceDetailQuery, SpecificOccurrenceDetailVm>
    {
        private readonly IRangenDbContext _context;
        private readonly IMapper _mapper;

        public GetSpecificOccurrenceDetailQueryHandler(IRangenDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SpecificOccurrenceDetailVm> Handle(GetSpecificOccurrenceDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SpecificOccurrences
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SpecificOccurrence), request.Id);
            }

            return _mapper.Map<SpecificOccurrenceDetailVm>(entity);
        }
    }

}
