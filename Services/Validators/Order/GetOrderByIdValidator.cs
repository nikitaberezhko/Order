using FluentValidation;
using Services.Services.Models.Request.Order;

namespace Services.Validators.Order;

public class GetOrderByIdValidator : AbstractValidator<GetOrderByIdModel>
{
    public GetOrderByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}