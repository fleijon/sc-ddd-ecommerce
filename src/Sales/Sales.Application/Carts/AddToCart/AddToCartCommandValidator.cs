using FluentValidation;

namespace Sales.Application.Carts
{
    public class AddToCartCommandValidator : AbstractValidator<AddToCartCommand>
    {
        // TODO: Validate currency?
    }
}