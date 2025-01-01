using Api.Entities.v1;
using BuildingBlock.CQRS;
using Mapster;
using Marten;
using MediatR;

namespace Api.Products.v1.UpdateProduct;

public class UpdateProductCommandHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand>
{
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken) ?? throw new Exception("Product not found");

        product = request.Adapt<Product>();

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}