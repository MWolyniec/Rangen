using MediatR;
using Rangen.Application.Common.Interfaces;
using Rangen.Application.Queries.GetRelationTypes;
using Rangen.Domain.Common;
using Rangen.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.RelationTypes.Upsert
{
    public class UpsertRelationTypeCommand : IRequest<int>
    {
        public UpsertRelationTypeCommand(string name)
        {
            this.Name = name;
        }

        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public ICollection<AdditionalDataObject> AdditionalData { get; set; }

        public bool Transitive { get; set; }
        public RelationTypeLookupDto MirroredType { get; set; }

        public class Handler : IRequestHandler<UpsertRelationTypeCommand, int>
        {
            private readonly IRangenDbContext _context;

            public Handler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpsertRelationTypeCommand request, CancellationToken cancellationToken)
            {
                RelationType entity;

                if (request.Id.HasValue)
                {
                    entity = await _context.RelationTypes.FindAsync(request.Id.Value);
                    entity.Name = request.Name;
                }
                else
                {
                    entity = new RelationType(request.Name);

                    _context.RelationTypes.Add(entity);
                }

                entity.Description = request.Description;

                entity.Transitive = request.Transitive;

                entity.MirroredType = await _context.RelationTypes.FindAsync(request.MirroredType.Id);

                entity.AdditionalData = request.AdditionalData;


                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
