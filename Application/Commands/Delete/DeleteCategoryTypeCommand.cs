using MediatR;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.Delete
{
    public class DeleteCategoryTypeCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteCategoryTypeCommandHandler : IRequestHandler<DeleteCategoryTypeCommand>
        {
            private readonly IRangenDbContext _context;

            public DeleteCategoryTypeCommandHandler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteCategoryTypeCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.CategoryTypes
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(CategoryType), request.Id);
                }

                _context.CategoryTypes.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
