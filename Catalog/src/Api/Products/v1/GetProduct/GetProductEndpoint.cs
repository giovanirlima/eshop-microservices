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
        });
    }
}