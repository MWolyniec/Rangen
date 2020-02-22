using FluentValidation;

namespace Rangen.Application.Commands.Relations.CreateRelation
{
    public class CreateRelationCommandValidator : AbstractValidator<CreateRelationCommand>
    {

        public CreateRelationCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(60).NotEmpty();

        }
    }
}
