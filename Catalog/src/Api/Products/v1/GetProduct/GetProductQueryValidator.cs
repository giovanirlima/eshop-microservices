using FluentValidation;

namespace Api.Products.v1.GetProduct;

public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
{
    public GetProductQueryValidator()
    {
        RuleFor(x => x.Offset)
            .GreaterThan(0)
                .WithMessage("Offset must be greater than to 0.");

        RuleFor(x => x.Limit)
            .GreaterThan(0)
                .WithMessage("Limit must be greater than to 0.");
    }
}