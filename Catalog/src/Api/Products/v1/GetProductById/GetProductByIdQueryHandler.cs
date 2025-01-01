using Api.Entities.v1;
using BuildingBlock.CQRS;
using Marten;

namespace Api.Products.v1.GetProductById;

public class GetProductByIdQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, Product>
{
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await session.LoadAsync<Product>(request.Id, cancellationToken) ?? new();
    }
}