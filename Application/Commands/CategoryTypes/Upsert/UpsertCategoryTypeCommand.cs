using MediatR;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.GetCategories;
using Rangen.Domain.Common;
using Rangen.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.CategoryTypes.Upsert
{
    public class UpsertCategoryTypeCommand : IRequest<int>
    {
        public UpsertCategoryTypeCommand(string name)
        {
            this.Name = name;
        }

        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public ICollection<AdditionalDataObject> AdditionalData { get; set; }

        public ICollection<CategoryLookupDto> Categories { get; set; }

        public class Handler : IRequestHandler<UpsertCategoryTypeCommand, int>
        {
            private readonly IRangenDbContext _context;

            public Handler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpsertCategoryTypeCommand request, CancellationToken cancellationToken)
            {
                CategoryType entity;

                if (request.Id.HasValue)
                {
                    entity = await _context.CategoryTypes.FindAsync(request.Id.Value);
                    entity.Name = request.Name;
                }
                else
                {
                    entity = new CategoryType(request.Name);

                    _context.CategoryTypes.Add(entity);
                }

                entity.Description = request.Description;

                entity.Categories = new List<Category>();
                foreach (var category in request.Categories)
                {
                    var cat = await _context.Categories.FindAsync(category.Id);
                    if (cat != null) entity.Categories.Add(cat);
                }

                entity.AdditionalData = request.AdditionalData;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
