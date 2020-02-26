using FluentValidation;

namespace Rangen.Application.Commands.SpecificOccurrences.UpdateSpecificOccurrence
{
    public class UpdateSpecificOccurrenceValidator : AbstractValidator<UpdateSpecificOccurrenceCommand>
    {
        public UpdateSpecificOccurrenceValidator()
        {
            RuleFor(x => x.Name).MaximumLength(60).NotEmpty();
        }
    }
}
