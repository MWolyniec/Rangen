using FluentValidation;

namespace Rangen.Application.Commands.GenericOccurrences.CreateGenericOccurrence
{
    public class CreateGenericOccurrenceCommandValidator : AbstractValidator<CreateGenericOccurrenceCommand>
    {

        public CreateGenericOccurrenceCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(60).NotEmpty();

        }
    }
}
