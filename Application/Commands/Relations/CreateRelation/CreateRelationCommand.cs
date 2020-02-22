using MediatR;
using Microsoft.EntityFrameworkCore;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Common;
using Rangen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.Relations.CreateRelation
{
    public class CreateRelationCommand : IRequest
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

        public class Handler : IRequestHandler<CreateRelationCommand>
        {

            private readonly IRangenDbContext _context;
            public Handler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateRelationCommand request, CancellationToken cancellationToken)
            {
                Occurrence occurrence1;
                Occurrence occurrence2;


                if (request.Occurrence1IsGeneric)
                    occurrence1 = await _context.GenericOccurrences.SingleOrDefaultAsync(x => x.Id == request.Occurrence1Id, cancellationToken);
                else
                    occurrence1 = await _context.SpecificOccurrences.SingleOrDefaultAsync(x => x.Id == request.Occurrence1Id, cancellationToken);


                if (request.Occurrence2IsGeneric)
                    occurrence2 = await _context.GenericOccurrences.SingleOrDefaultAsync(x => x.Id == request.Occurrence2Id, cancellationToken);
                else
                    occurrence2 = await _context.SpecificOccurrences.SingleOrDefaultAsync(x => x.Id == request.Occurrence2Id, cancellationToken);

                RelationType relationType = await _context.RelationTypes.SingleOrDefaultAsync(x => x.Id == request.RelationTypeId, cancellationToken);


                _ = occurrence1 ?? throw new ArgumentNullException(nameof(occurrence1));
                _ = occurrence2 ?? throw new ArgumentNullException(nameof(occurrence2));
                _ = relationType ?? throw new ArgumentNullException(nameof(relationType));

                var entity = new Relation(request.Name)
                {
                    Description = request.Description,
                    Occurrence1 = occurrence1,
                    Occurrence1Id = request.Occurrence1Id,
                    Occurrence2 = occurrence2,
                    Occurrence2Id = request.Occurrence2Id,
                    Occurrence1ChanceToOccurInTheRelation = request.Occurrence1ChanceToOccurInTheRelation,
                    Occurrence2ChanceToOccurInTheRelation = request.Occurrence2ChanceToOccurInTheRelation,
                    RelationType = relationType

                };


                _context.Relations.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
