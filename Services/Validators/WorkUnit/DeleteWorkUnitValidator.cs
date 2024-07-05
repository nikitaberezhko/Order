using FluentValidation;
using Services.Services.Models.Request.WorkUnit;

namespace Services.Validators.WorkUnit;

public class DeleteWorkUnitValidator : AbstractValidator<DeleteWorkUnitModel>
{
    public DeleteWorkUnitValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}