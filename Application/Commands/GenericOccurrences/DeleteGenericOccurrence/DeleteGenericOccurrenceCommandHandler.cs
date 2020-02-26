using MediatR;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.GenericOccurrences.DeleteGenericOccurrence
{
    class DeleteGenericOccurrenceCommandHandler : IRequestHandler<DeleteGenericOccurrenceCommand>
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

            _ = entity ?? throw new NotFoundException(nameof(GenericOccurrence), request.Id);


            _context.GenericOccurrences.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
