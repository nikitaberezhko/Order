using FluentValidation;
using Services.Services.Models.Request.Order;

namespace Services.Validators.Order;

public class CreateOrderValidator : AbstractValidator<CreateOrderModel>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.ClientId)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.Model)
            .NotEmpty();
        
        RuleFor(x => x.ModelProductionDate)
            .NotEmpty();
    }
}