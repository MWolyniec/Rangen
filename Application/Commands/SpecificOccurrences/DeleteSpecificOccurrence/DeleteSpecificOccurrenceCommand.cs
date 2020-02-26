using MediatR;

namespace Rangen.Application.Commands.SpecificOccurrences.DeleteSpecificOccurrence
{
    public class DeleteSpecificOccurrenceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
