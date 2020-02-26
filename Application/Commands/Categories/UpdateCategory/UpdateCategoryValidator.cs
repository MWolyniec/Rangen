using FluentValidation;

namespace Rangen.Application.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name).MaximumLength(60).NotEmpty();
        }
    }
}
