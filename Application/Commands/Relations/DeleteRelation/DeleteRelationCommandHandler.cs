using MediatR;
using Rangen.Application.Commands.Common;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.Relations.DeleteRelation
{
    public class DeleteRelationCommandHandler : DeleteItemCommandHandler<Relation>
    {

        public DeleteRelationCommandHandler(IRangenDbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Relations.FindAsync(request.Id);

            if (entity?.Occurrence1?.RelationsAsOccurrence1?.Contains(entity) == true)
                entity?.Occurrence1?.RelationsAsOccurrence1?.Remove(entity);

            if (entity?.Occurrence1?.RelationsAsOccurrence2?.Contains(entity) == true)
                entity?.Occurrence1?.RelationsAsOccurrence2?.Remove(entity);

            if (entity?.Occurrence2?.RelationsAsOccurrence1?.Contains(entity) == true)
                entity?.Occurrence2?.RelationsAsOccurrence1?.Remove(entity);

            if (entity?.Occurrence2?.RelationsAsOccurrence2?.Contains(entity) == true)
                entity?.Occurrence2?.RelationsAsOccurrence2?.Remove(entity);

            return await Handle_Base(_context.Relations, request, cancellationToken);
        }
    }
}
