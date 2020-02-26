using FluentValidation;

namespace Rangen.Application.Commands.SpecificOccurrences.CreateSpecificOccurrence
{
    public class CreateSpecificOccurrenceCommandValidator : AbstractValidator<CreateSpecificOccurrenceCommand>
    {

        public CreateSpecificOccurrenceCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(60).NotEmpty();

        }
    }
}
