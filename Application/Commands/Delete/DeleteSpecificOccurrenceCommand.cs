using MediatR;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.Delete
{
    public class DeleteSpecificOccurrenceCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteSpecificOccurrenceCommandHandler : IRequestHandler<DeleteSpecificOccurrenceCommand>
        {
            private readonly IRangenDbContext _context;

            public DeleteSpecificOccurrenceCommandHandler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteSpecificOccurrenceCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.SpecificOccurrences
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(SpecificOccurrence), request.Id);
                }

                _context.SpecificOccurrences.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
