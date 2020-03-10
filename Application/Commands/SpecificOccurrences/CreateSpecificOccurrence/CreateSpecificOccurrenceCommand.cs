using MediatR;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.GetGenericOccurrences;
using Rangen.Domain.Common;
using Rangen.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.SpecificOccurrences.CreateSpecificOccurrence
{
    public class CreateSpecificOccurrenceCommand : IRequest<int>
    {
        public CreateSpecificOccurrenceCommand(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public float RelativeAge { get; set; }
        public float RelativeSize { get; set; }

        public GenericOccurrenceLookupDto OccurrenceType { get; set; }

        public byte DryoutFactor { get; set; }
        public ICollection<AdditionalDataObject> AdditionalData { get; set; }



        public class Handler : IRequestHandler<CreateSpecificOccurrenceCommand, int>
        {

            private readonly IRangenDbContext _context;

            public Handler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateSpecificOccurrenceCommand request, CancellationToken cancellationToken)
            {


                var entity = new SpecificOccurrence(request.Name);


                _context.SpecificOccurrences.Add(entity);

                var entry = _context.Entry(entity);
                entry.CurrentValues.SetValues(request);

                entity.AdditionalData = request.AdditionalData;

                entity.OccurrenceType = await _context.GenericOccurrences.FindAsync(request.OccurrenceType.Id);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
