using FluentValidation;
using Services.Services.Models.Request.WorkUnit;

namespace Services.Validators.WorkUnit;

public class CreateWorkUnitValidator : AbstractValidator<CreateWorkUnitModel>
{
    public CreateWorkUnitValidator()
    {
        RuleFor(x => x.OrderId)
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