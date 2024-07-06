using FluentValidation;
using Services.Services.Models.Request.Order;

namespace Services.Validators.Order;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderModel>
{
    public UpdateOrderValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.ManagerId)
            .NotEmpty()
            .NotEqual(Guid.Empty);

        RuleFor(x => x.Model)
            .NotEmpty();
        
        RuleFor(x => x.ModelProductionDate)
            .NotEmpty();
    }
}