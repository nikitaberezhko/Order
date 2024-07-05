using FluentValidation;
using Services.Services.Models.Request.Order;

namespace Services.Validators.Order;

public class GetOrdersByClientIdValidator : AbstractValidator<GetOrdersByClientIdModel>
{
    public GetOrdersByClientIdValidator()
    {
        RuleFor(x => x.ClientId)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}