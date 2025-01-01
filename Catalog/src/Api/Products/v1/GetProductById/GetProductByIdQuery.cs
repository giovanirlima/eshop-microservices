using Api.Entities.v1;
using BuildingBlock.CQRS;

namespace Api.Products.v1.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<Product>;