using FluentValidation;

namespace Api.Products.v1.AddProduct;

public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
                .WithMessage("Name is required");

        RuleFor(x => x.Category)
            .NotEmpty()
                .WithMessage("Category is required");

        RuleFor(x => x.ImageFile)
            .NotEmpty()
                .WithMessage("ImageFile is required");

        RuleFor(x => x.Price)
            .GreaterThan(0)
                .WithMessage("Price must be greater than 0");
    }
}