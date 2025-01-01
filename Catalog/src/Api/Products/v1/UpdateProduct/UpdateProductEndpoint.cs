using Carter;
using MediatR;

namespace Api.Products.v1.UpdateProduct;

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/v1/product/{id:Guid}",
            async (Guid id, UpdateProductCommand request, ISender sender) =>
        {
            await sender.Send(request.SetIdProperty(id));

            return Results.NoContent();
        })
        .WithName("UpdateProduct")
        .Produces(StatusCodes.Status204NoContent)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Product")
        .WithDescription("Update Product");
    }
}