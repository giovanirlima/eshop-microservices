using FluentValidation;

namespace Api.Products.v1.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
                .WithMessage("Id is required");

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