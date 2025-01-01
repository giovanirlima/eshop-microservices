using BuildingBlock.CQRS;

namespace Api.Products.v1.DeleteProduct;

public class DeleteProductCommand : ICommand
{
    public Guid Id { get; private set; }

    public DeleteProductCommand SetIdProperty(Guid id)
    {
        Id = id;
        return this;
    }
}