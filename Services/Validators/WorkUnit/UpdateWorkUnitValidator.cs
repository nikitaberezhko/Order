using FluentValidation;
using Services.Services.Models.Request.WorkUnit;

namespace Services.Validators.WorkUnit;

public class UpdateWorkUnitValidator : AbstractValidator<UpdateWorkUnitModel>
{
    public UpdateWorkUnitValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.Name)
            .NotEmpty();
        
        RuleFor(x => x.Description)
            .NotEmpty();
        
        RuleFor(x => x.Price)
            .NotEmpty();
    }
}