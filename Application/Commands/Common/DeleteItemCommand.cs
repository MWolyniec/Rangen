using MediatR;

namespace Rangen.Application.Commands.Common
{
    public class DeleteItemCommand : IRequest
    {
        public int Id { get; set; }

    }
}
