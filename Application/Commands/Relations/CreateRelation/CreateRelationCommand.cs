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
    public class CreateRelationCommand : IRequest<int>
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

        public HashSet<AdditionalDataObject> AdditionalData { get; set; }

        public CreateRelationCommand(string name, int occurrence1Id, bool occurrence1IsGeneric,
            int occurrence2Id, bool occurrence2IsGeneric, int relationTypeId)
        {
            this.Name = name;
            this.Occurrence1Id = occurrence1Id;
            this.Occurrence1IsGeneric = occurrence1IsGeneric;
            this.Occurrence2Id = occurrence2Id;
            this.Occurrence2IsGeneric = occurrence2IsGeneric;
            this.RelationTypeId = relationTypeId;
        }

        public class Handler : IRequestHandler<CreateRelationCommand, int>
        {

            private readonly IRangenDbContext _context;

            public Handler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateRelationCommand request, CancellationToken cancellationToken)
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

                entity.Occurrence1.RelationsAsOccurrence1.Add(entity);
                entity.Occurrence2.RelationsAsOccurrence2.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
