using MediatR;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.Delete
{
    public class DeleteGenericOccurrenceCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteGenericOccurrenceCommandHandler : IRequestHandler<DeleteGenericOccurrenceCommand>
        {
            private readonly IRangenDbContext _context;

            public DeleteGenericOccurrenceCommandHandler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteGenericOccurrenceCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.GenericOccurrences
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(GenericOccurrence), request.Id);
                }

                _context.GenericOccurrences.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
