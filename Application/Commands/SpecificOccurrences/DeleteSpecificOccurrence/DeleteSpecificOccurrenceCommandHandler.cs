using MediatR;
using Rangen.Application.Commands.Common;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.SpecificOccurrences.DeleteSpecificOccurrence
{
    public class DeleteSpecificOccurrenceCommandHandler : DeleteItemCommandHandler<SpecificOccurrence>
    {

        public DeleteSpecificOccurrenceCommandHandler(IRangenDbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            return await Handle_Base(_context.SpecificOccurrences, request, cancellationToken);
        }
    }
}
