using MediatR;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.RelationTypes.Delete
{
    public class DeleteRelationTypeCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteRelationTypeCommandHandler : IRequestHandler<DeleteRelationTypeCommand>
        {
            private readonly IRangenDbContext _context;

            public DeleteRelationTypeCommandHandler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteRelationTypeCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.RelationTypes
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(RelationType), request.Id);
                }

                _context.RelationTypes.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
