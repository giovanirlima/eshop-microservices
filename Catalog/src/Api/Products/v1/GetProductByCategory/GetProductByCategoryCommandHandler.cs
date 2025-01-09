using Api.Entities.v1;
using BuildingBlock.CQRS;
using Marten;

namespace Api.Products.v1.GetProductByCategory;

public class GetProductByCategoryCommandHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryCommand, IEnumerable<Product>>
{
    public async Task<IEnumerable<Product>> Handle(GetProductByCategoryCommand request, CancellationToken cancellationToken) =>
        await session.Query<Product>()
            .Where(p => p.Category
            .Contains(request.Category))
            .ToListAsync(cancellationToken);
}