using FluentValidation;

namespace Countify.Application.Features.FiscalControls.Commands.UpdateFiscalControl;

public class UpdateFiscalControlCommandValidator : AbstractValidator<UpdateFiscalControlCommand>
{
    public UpdateFiscalControlCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.DocumentType).IsInEnum();
        RuleFor(x => x.Branch).MaximumLength(20);
        RuleFor(x => x.EmissionPoint).MaximumLength(20);
        RuleFor(x => x.DocumentCode).MaximumLength(4);
        RuleFor(x => x.CAI).MaximumLength(100);
        RuleFor(x => x.RangeFrom).MaximumLength(50);
        RuleFor(x => x.RangeTo).MaximumLength(50);
        RuleFor(x => x.Observations).MaximumLength(500);
    }
}
