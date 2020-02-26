using MediatR;
using Microsoft.EntityFrameworkCore;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.GenericOccurrences.UpdateGenericOccurrence
{
    public class UpdateGenericOccurrenceCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public float GeneralChanceToOccur { get; set; }

        public ICollection<Relation> Relations { get; set; }
        public IDictionary<string, object> AdditionalData { get; set; }

        public class UpdateGenericOccurrenceCommandHandler : IRequestHandler<UpdateGenericOccurrenceCommand, int>
        {
            private readonly IRangenDbContext _context;

            public UpdateGenericOccurrenceCommandHandler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateGenericOccurrenceCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.GenericOccurrences.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                _ = entity ?? throw new NotFoundException(nameof(GenericOccurrence), request.Id);


                var entry = _context.Entry(entity);
                entry.CurrentValues.SetValues(request);


                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}

