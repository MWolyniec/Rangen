using MediatR;

namespace Rangen.Application.Queries.GetSpecificOccurrences
{
    public class GetSpecificOccurrenceDetailQuery : IRequest<SpecificOccurrenceDetailVm>
    {
        public int Id { get; set; }
    }
}
