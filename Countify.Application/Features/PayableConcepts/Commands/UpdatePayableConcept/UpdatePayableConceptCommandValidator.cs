using FluentValidation;

namespace Countify.Application.Features.PayableConcepts.Commands.UpdatePayableConcept;

public class UpdatePayableConceptCommandValidator : AbstractValidator<UpdatePayableConceptCommand>
{
    public UpdatePayableConceptCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Observations).MaximumLength(500);
    }
}
