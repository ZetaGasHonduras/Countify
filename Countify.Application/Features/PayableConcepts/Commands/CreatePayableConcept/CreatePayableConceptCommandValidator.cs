using FluentValidation;

namespace Countify.Application.Features.PayableConcepts.Commands.CreatePayableConcept;

public class CreatePayableConceptCommandValidator : AbstractValidator<CreatePayableConceptCommand>
{
    public CreatePayableConceptCommandValidator()
    {
        RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Observations).MaximumLength(500);
    }
}
