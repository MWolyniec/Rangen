using MediatR;
using Rangen.Application.Commands.Common;
using Rangen.Application.Common.Interfaces;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Commands.GenericOccurrences.DeleteGenericOccurrence
{
    public class DeleteGenericOccurrenceCommandHandler : DeleteItemCommandHandler<GenericOccurrence>
    {

        public DeleteGenericOccurrenceCommandHandler(IRangenDbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            return await Handle_Base(_context.GenericOccurrences, request, cancellationToken);
        }
    }
}
