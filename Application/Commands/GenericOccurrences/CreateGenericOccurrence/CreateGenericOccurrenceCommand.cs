using MediatR;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.GenericOccurrences.CreateGenericOccurrence
{
    public class CreateGenericOccurrenceCommand : IRequest
    {

        public string Name { get; set; }

        public string Description { get; set; }
        public float GeneralChanceToOccur { get; set; }

        public ICollection<Relation> Relations { get; set; }
        public IDictionary<string, object> AdditionalData { get; set; }

        public class Handler : IRequestHandler<CreateGenericOccurrenceCommand>
        {

            private readonly IRangenDbContext _context;

            public Handler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateGenericOccurrenceCommand request, CancellationToken cancellationToken)
            {



                var entity = new GenericOccurrence(request.Name);


                _context.GenericOccurrences.Add(entity);

                var entry = _context.Entry(entity);
                entry.CurrentValues.SetValues(request);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
