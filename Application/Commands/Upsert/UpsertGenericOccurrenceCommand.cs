using MediatR;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.Upsert
{
    public class UpsertGenericOccurrenceCommand : IRequest<int>
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float GeneralChanceToOccur { get; set; }

        public class UpsertGenericOccurrenceCommandHandler : IRequestHandler<UpsertGenericOccurrenceCommand, int>
        {
            private readonly IRangenDbContext _context;

            public UpsertGenericOccurrenceCommandHandler(IRangenDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpsertGenericOccurrenceCommand request, CancellationToken cancellationToken)
            {
                GenericOccurrence entity;

                if (request.Id.HasValue)
                {
                    entity = await _context.GenericOccurrences.FindAsync(request.Id.Value);
                }
                else
                {
                    entity = new GenericOccurrence(request.Name);

                    _context.GenericOccurrences.Add(entity);
                }

                entity.Description = request.Description;
                entity.GeneralChanceToOccur = request.GeneralChanceToOccur;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
