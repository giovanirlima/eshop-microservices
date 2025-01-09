using FluentValidation;

namespace Api.Products.v1.GetProductByCategory;

public class GetProductByCategoryCommandValidator : AbstractValidator<GetProductByCategoryCommand>
{
    public GetProductByCategoryCommandValidator()
    {
        RuleFor(x => x.Category)
            .NotEmpty()
                .WithMessage("Category is required.");
    }
}