using Api.Entities.v1;
using BuildingBlock.CQRS;
using Mapster;
using Marten;
using MediatR;

namespace Api.Products.v1.AddProduct;

public class AddProductCommandHandler(IDocumentSession session) : ICommandHandler<AddProductCommand>
{
    public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.Adapt<Product>();

        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}