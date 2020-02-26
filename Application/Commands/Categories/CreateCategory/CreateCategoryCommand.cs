using MediatR;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.Categories.CreateCategory
{
    public class CreateCategoryCommand : IRequest
    {

        public string Name { get; set; }

        public string Description { get; set; }
        public float GeneralChanceToOccur { get; set; }

        public ICollection<Relation> Relations { get; set; }
        public IDictionary<string, object> AdditionalData { get; set; }

        public class Handler : IRequestHandler<CreateCategoryCommand>
        {

            private readonly IRangenDbContext _context;

            public Handler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {



                var entity = new Category(request.Name);


                _context.Categories.Add(entity);

                var entry = _context.Entry(entity);
                entry.CurrentValues.SetValues(request);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
