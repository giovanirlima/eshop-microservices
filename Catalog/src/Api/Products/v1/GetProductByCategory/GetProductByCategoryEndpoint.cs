using Carter;
using MediatR;

namespace Api.Products.v1.GetProductByCategory;

public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/product/category/{category}",
            async (string category, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByCategoryCommand(category));
            return Results.Ok(result);
        });
    }
}