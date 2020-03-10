using MediatR;
using Microsoft.EntityFrameworkCore;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.GetCategoryTypes;
using Rangen.Application.Queries.GetGenericOccurrences;
using Rangen.Domain.Common;
using Rangen.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.Categories.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public CreateCategoryCommand(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public CategoryTypeLookupDto CategoryType { get; set; }
        public ICollection<GenericOccurrenceLookupDto> GenericOccurrences { get; set; }

        public ICollection<AdditionalDataObject> AdditionalData { get; set; }

        public class Handler : IRequestHandler<CreateCategoryCommand, int>
        {

            private readonly IRangenDbContext _context;

            public Handler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {



                var entity = new Category(request.Name);


                _context.Categories.Add(entity);

                var entry = _context.Entry(entity);
                entry.CurrentValues.SetValues(request);

                entity.AdditionalData = request.AdditionalData;
                entity.CategoryType = await _context.CategoryTypes.FindAsync(request.CategoryType.Id);
                entity.GenericOccurrences = await _context.GenericOccurrences.Where(x => request.GenericOccurrences.Select(d => d.Id).Contains(x.Id)).ToListAsync();

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
