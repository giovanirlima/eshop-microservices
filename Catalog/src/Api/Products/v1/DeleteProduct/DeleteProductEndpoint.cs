using Carter;
using MediatR;

namespace Api.Products.v1.DeleteProduct;

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/v1/product/{id}",
            async (Guid id, ISender sender) =>
        {
            await sender.Send(new DeleteProductCommand().SetIdProperty(id));

            return Results.NoContent();
        })
        .WithName("DeleteProduct")
        .Produces(StatusCodes.Status204NoContent)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
    }
}