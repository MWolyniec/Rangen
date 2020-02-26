using MediatR;
using Microsoft.EntityFrameworkCore;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Common;
using Rangen.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.Relations.UpdateRelation
{
    public class UpdateRelationCommand : IRequest<int>
    {
        public int Id { get; set; }
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

        public class UpdateRelationCommandHandler : IRequestHandler<UpdateRelationCommand, int>
        {
            private readonly IRangenDbContext _context;

            public UpdateRelationCommandHandler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateRelationCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Relations.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);


                _ = entity ?? throw new NotFoundException(nameof(Relation), request.Id);


                var entry = _context.Entry(entity);
                entry.CurrentValues.SetValues(request);

                Occurrence occurrence1;
                if (request.Occurrence1IsGeneric)
                {
                    occurrence1 = await _context.GenericOccurrences.SingleOrDefaultAsync(x => x.Id == request.Occurrence1Id, cancellationToken);
                    _ = occurrence1 ?? throw new NotFoundException(nameof(GenericOccurrence), occurrence1);

                }
                else
                {
                    occurrence1 = await _context.SpecificOccurrences.SingleOrDefaultAsync(x => x.Id == request.Occurrence1Id, cancellationToken);
                    _ = occurrence1 ?? throw new NotFoundException(nameof(SpecificOccurrence), occurrence1);

                }
                entity.Occurrence1 = occurrence1;

                Occurrence occurrence2;
                if (request.Occurrence2IsGeneric)
                {
                    occurrence2 = await _context.GenericOccurrences.SingleOrDefaultAsync(x => x.Id == request.Occurrence2Id, cancellationToken);
                    _ = occurrence2 ?? throw new NotFoundException(nameof(GenericOccurrence), occurrence2);

                }
                else
                {
                    occurrence2 = await _context.SpecificOccurrences.SingleOrDefaultAsync(x => x.Id == request.Occurrence2Id, cancellationToken);
                    _ = occurrence2 ?? throw new NotFoundException(nameof(SpecificOccurrence), occurrence2);

                }
                entity.Occurrence2 = occurrence2;



                var relationType = await _context.RelationTypes.SingleOrDefaultAsync(x => x.Id == request.RelationTypeId, cancellationToken);

                _ = relationType ?? throw new NotFoundException(nameof(RelationType), relationType);

                entity.RelationType = relationType;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}

