using Api.Entities.v1;
using BuildingBlock.CQRS;

namespace Api.Products.v1.GetProductByCategory;

public record GetProductByCategoryCommand(string Category) : IQuery<IEnumerable<Product>>;