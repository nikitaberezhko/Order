using FluentValidation;
using Services.Services.Models.Request.Order;

namespace Services.Validators.Order;

public class DeleteOrderValidator : AbstractValidator<DeleteOrderModel>
{
    public DeleteOrderValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}