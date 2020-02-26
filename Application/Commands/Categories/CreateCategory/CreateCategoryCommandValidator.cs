using FluentValidation;

namespace Rangen.Application.Commands.Categories.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {

        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(60).NotEmpty();

        }
    }
}
