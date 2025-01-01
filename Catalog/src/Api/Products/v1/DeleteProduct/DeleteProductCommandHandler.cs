using Api.Entities.v1;
using BuildingBlock.CQRS;
using Marten;
using MediatR;

namespace Api.Products.v1.DeleteProduct;

public class DeleteProductCommandHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand>
{
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        session.Delete<Product>(request.Id);
        await session.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}