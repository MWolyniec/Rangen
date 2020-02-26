using FluentValidation;

namespace Rangen.Application.Commands.GenericOccurrences.UpdateGenericOccurrence
{
    public class UpdateGenericOccurrenceValidator : AbstractValidator<UpdateGenericOccurrenceCommand>
    {
        public UpdateGenericOccurrenceValidator()
        {
            RuleFor(x => x.Name).MaximumLength(60).NotEmpty();
        }
    }
}
