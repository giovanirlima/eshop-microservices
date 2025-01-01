using Carter;
using MediatR;

namespace Api.Products.v1.AddProduct;

public class AddProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/products",
            async (AddProductCommand request, ISender sender) =>
        {
            await sender.Send(request);

            return Results.Created();
        })
        .WithName("CreateProduct")
        .Produces(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Add Product")
        .WithDescription("Add Product");
    }
}