using MediatR;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.UpsertCategory
{
    public class UpsertRelationTypeCommand : IRequest<int>
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public RelationType MirroredType { get; set; }
        public bool Transitive { get; set; }

        public class UpsertRelationTypeCommandHandler : IRequestHandler<UpsertRelationTypeCommand, int>
        {
            private readonly IRangenDbContext _context;

            public UpsertRelationTypeCommandHandler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpsertRelationTypeCommand request, CancellationToken cancellationToken)
            {
                RelationType entity;

                if (request.Id.HasValue)
                {
                    entity = await _context.RelationTypes.FindAsync(request.Id.Value);
                }
                else
                {
                    entity = new RelationType(request.Name);

                    _context.RelationTypes.Add(entity);
                }

                entity.Description = request.Description;
                entity.Transitive = request.Transitive;
                entity.MirroredType = entity.MirroredType;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
