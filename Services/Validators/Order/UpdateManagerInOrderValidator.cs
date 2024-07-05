using FluentValidation;
using Services.Services.Models.Request.Order;

namespace Services.Validators.Order;

public class UpdateManagerInOrderValidator : AbstractValidator<UpdateManagerInOrderModel>
{
    public UpdateManagerInOrderValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.ManagerId)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}