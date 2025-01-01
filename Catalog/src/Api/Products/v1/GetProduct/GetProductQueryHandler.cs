using Api.Entities.v1;
using BuildingBlock.CQRS;
using Marten;
using Marten.Pagination;

namespace Api.Products.v1.GetProduct;

public class GetProductQueryHandler(IDocumentSession session) : IQueryHandler<GetProductQuery, IEnumerable<Product>>
{
    public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken) => 
        await session.Query<Product>().ToPagedListAsync(request.Offset, request.Limit, cancellationToken);
}