using FluentValidation;
using Services.Services.Models.Request.Order;

namespace Services.Validators.Order;

public class GetOrdersByManagerIdValidator : AbstractValidator<GetOrdersByManagerIdModel>
{
    public GetOrdersByManagerIdValidator()
    {
        RuleFor(x => x.ManagerId)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}