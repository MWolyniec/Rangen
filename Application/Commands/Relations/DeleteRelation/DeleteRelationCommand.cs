using MediatR;

namespace Rangen.Application.Commands.Relations.DeleteRelation
{
    public class DeleteRelationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
