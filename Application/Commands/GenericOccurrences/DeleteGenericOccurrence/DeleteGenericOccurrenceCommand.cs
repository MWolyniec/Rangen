using MediatR;

namespace Rangen.Application.Commands.GenericOccurrences.DeleteGenericOccurrence
{
    public class DeleteGenericOccurrenceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
