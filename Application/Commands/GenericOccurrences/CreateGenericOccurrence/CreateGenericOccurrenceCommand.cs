using MediatR;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Common;
using Rangen.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.GenericOccurrences.CreateGenericOccurrence
{
    public class CreateGenericOccurrenceCommand : IRequest<int>
    {

        public string Name { get; set; }

        public string Description { get; set; }
        public float GeneralChanceToOccur { get; set; }

        public ICollection<Relation> Relations { get; set; }
        public ICollection<AdditionalDataObject> AdditionalData { get; set; }

        public CreateGenericOccurrenceCommand(string name)
        {
            this.Name = name;
        }

        public class Handler : IRequestHandler<CreateGenericOccurrenceCommand, int>
        {

            private readonly IRangenDbContext _context;

            public Handler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateGenericOccurrenceCommand request, CancellationToken cancellationToken)
            {



                var entity = new GenericOccurrence(request.Name);


                _context.GenericOccurrences.Add(entity);

                _context.Entry(entity).CurrentValues.SetValues(request);

                entity.AdditionalData = request.AdditionalData;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
