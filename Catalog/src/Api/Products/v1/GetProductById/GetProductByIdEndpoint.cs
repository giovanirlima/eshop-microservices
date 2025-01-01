using Api.Entities.v1;
using Carter;
using MediatR;

namespace Api.Products.v1.GetProductById;

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/product/{id:Guid}",
            async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));

            return Results.Ok(result);
        })
        .WithName("GetProductById")
        .Produces<Product>(StatusCodes.Status200OK)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }
}