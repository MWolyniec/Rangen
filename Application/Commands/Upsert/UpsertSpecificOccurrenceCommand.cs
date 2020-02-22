using MediatR;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.UpsertCategory
{
    public class UpsertSpecificOccurrenceCommand : IRequest<int>
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float RelativeAge { get; set; }
        public float RelativeSize { get; set; }

        public GenericOccurrence OccurrenceType { get; set; }

        public byte DryoutFactor { get; set; }

        public ICollection<Relation> GenericRelations { get; set; }

        public class UpsertSpecificOccurrenceCommandHandler : IRequestHandler<UpsertSpecificOccurrenceCommand, int>
        {
            private readonly IRangenDbContext _context;

            public UpsertSpecificOccurrenceCommandHandler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpsertSpecificOccurrenceCommand request, CancellationToken cancellationToken)
            {
                SpecificOccurrence entity;

                if (request.Id.HasValue)
                {
                    entity = await _context.SpecificOccurrences.FindAsync(request.Id.Value);
                }
                else
                {
                    entity = new SpecificOccurrence(request.Name);

                    _context.SpecificOccurrences.Add(entity);
                }

                entity.Description = request.Description;
                entity.RelativeAge = request.RelativeAge;
                entity.RelativeSize = request.RelativeSize;
                entity.OccurrenceType = request.OccurrenceType;
                entity.DryoutFactor = request.DryoutFactor;
                entity.GenericRelations = request.GenericRelations;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
