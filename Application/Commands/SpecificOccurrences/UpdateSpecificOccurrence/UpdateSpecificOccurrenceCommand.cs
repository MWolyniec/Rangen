using MediatR;
using Microsoft.EntityFrameworkCore;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.SpecificOccurrences.UpdateSpecificOccurrence
{
    public class UpdateSpecificOccurrenceCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float RelativeAge { get; set; }
        public float RelativeSize { get; set; }

        public int OccurrenceTypeId { get; set; }

        public byte DryoutFactor { get; set; }
        public IDictionary<string, object> AdditionalData { get; set; }

        public class UpdateSpecificOccurrenceCommandHandler : IRequestHandler<UpdateSpecificOccurrenceCommand, int>
        {
            private readonly IRangenDbContext _context;

            public UpdateSpecificOccurrenceCommandHandler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateSpecificOccurrenceCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.SpecificOccurrences.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                _ = entity ?? throw new NotFoundException(nameof(SpecificOccurrence), request.Id);


                var entry = _context.Entry(entity);
                entry.CurrentValues.SetValues(request);

                var occurrenceType = await _context.GenericOccurrences.SingleOrDefaultAsync(x => x.Id == request.OccurrenceTypeId, cancellationToken);
                _ = occurrenceType ?? throw new NotFoundException(nameof(GenericOccurrences), request.OccurrenceTypeId);

                entity.OccurrenceType = occurrenceType;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}

