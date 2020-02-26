using MediatR;
using Microsoft.EntityFrameworkCore;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public float GeneralChanceToOccur { get; set; }

        public ICollection<Relation> Relations { get; set; }
        public IDictionary<string, object> AdditionalData { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
        {
            private readonly IRangenDbContext _context;

            public UpdateCategoryCommandHandler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Categories.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                _ = entity ?? throw new NotFoundException(nameof(Category), request.Id);


                var entry = _context.Entry(entity);
                entry.CurrentValues.SetValues(request);


                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}

