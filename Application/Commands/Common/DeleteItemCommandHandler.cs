using MediatR;
using Microsoft.EntityFrameworkCore;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.Common
{
    public abstract class DeleteItemCommandHandler<TEntity> : IRequestHandler<DeleteItemCommand> where TEntity : class
    {
        protected readonly IRangenDbContext _context;

        public DeleteItemCommandHandler(IRangenDbContext context)
        {
            _context = context;
        }

        public abstract Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken);

        protected async Task<Unit> Handle_Base(DbSet<TEntity> dbSet, DeleteItemCommand request, CancellationToken cancellationToken)
        {

            var entity = await dbSet.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(typeof(TEntity).Name, request.Id);
            }

            dbSet.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }

}

