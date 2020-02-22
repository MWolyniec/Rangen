using MediatR;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.Delete
{
    public class DeleteRelationCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteRelationCommandHandler : IRequestHandler<DeleteRelationCommand>
        {
            private readonly IRangenDbContext _context;

            public DeleteRelationCommandHandler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteRelationCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Relations
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Relation), request.Id);
                }

                _context.Relations.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
