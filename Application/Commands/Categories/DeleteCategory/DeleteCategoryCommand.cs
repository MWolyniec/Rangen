using MediatR;

namespace Rangen.Application.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
