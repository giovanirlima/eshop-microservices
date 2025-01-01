using Api.Entities.v1;
using BuildingBlock.CQRS;

namespace Api.Products.v1.GetProduct;

public record GetProductQuery(int Offset, int Limit) : IQuery<IEnumerable<Product>>;