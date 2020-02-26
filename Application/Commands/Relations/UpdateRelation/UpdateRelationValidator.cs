using FluentValidation;

namespace Rangen.Application.Commands.Relations.UpdateRelation
{
    public class UpdateRelationValidator : AbstractValidator<UpdateRelationCommand>
    {
        public UpdateRelationValidator()
        {
            RuleFor(x => x.Name).MaximumLength(60).NotEmpty();
        }
    }
}
