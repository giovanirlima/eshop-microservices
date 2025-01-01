using Api.Entities.v1;
using Carter;
using MediatR;

namespace Api.Products.v1.GetProduct;

public class GetProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/product",
            async ([AsParameters] GetProductQuery request, ISender sender) =>
        {
            var results = await sender.Send(request);

            return Results.Ok(results);
        })
        .WithName("GetProducts")
        .Produces<IEnumerable<Product>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Products");
    }
}