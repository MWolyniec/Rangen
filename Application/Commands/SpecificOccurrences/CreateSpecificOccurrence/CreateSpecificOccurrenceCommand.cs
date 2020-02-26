using MediatR;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.SpecificOccurrences.CreateSpecificOccurrence
{
    public class CreateSpecificOccurrenceCommand : IRequest
    {



        public string Name { get; set; }
        public string Description { get; set; }

        public bool Occurrence1IsGeneric { get; set; }
        public int Occurrence1Id { get; set; }


        public bool Occurrence2IsGeneric { get; set; }
        public int Occurrence2Id { get; set; }

        public int RelationTypeId { get; set; }

        public float Occurrence1ChanceToOccurInTheRelation { get; set; }
        public float Occurrence2ChanceToOccurInTheRelation { get; set; }

        public IDictionary<string, object> AdditionalData { get; set; }

        public class Handler : IRequestHandler<CreateSpecificOccurrenceCommand>
        {

            private readonly IRangenDbContext _context;

            public Handler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateSpecificOccurrenceCommand request, CancellationToken cancellationToken)
            {


                var entity = new SpecificOccurrence(request.Name);


                _context.SpecificOccurrences.Add(entity);

                var entry = _context.Entry(entity);
                entry.CurrentValues.SetValues(request);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
