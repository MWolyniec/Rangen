using MediatR;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.CategoryTypes.UpsertCategoryType
{
    public class UpsertCategoryTypeCommand : IRequest<int>
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public ICollection<Category> Categories { get; set; }

        public class UpsertCategoryTypeCommandHandler : IRequestHandler<UpsertCategoryTypeCommand, int>
        {
            private readonly IRangenDbContext _context;

            public UpsertCategoryTypeCommandHandler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpsertCategoryTypeCommand request, CancellationToken cancellationToken)
            {
                CategoryType entity;

                if (request.Id.HasValue)
                {
                    entity = await _context.CategoryTypes.FindAsync(request.Id.Value);
                }
                else
                {
                    entity = new CategoryType(request.Name);

                    _context.CategoryTypes.Add(entity);
                }

                entity.Description = request.Description;

                entity.Categories = request.Categories;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
