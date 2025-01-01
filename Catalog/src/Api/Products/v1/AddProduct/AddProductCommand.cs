using BuildingBlock.CQRS;

namespace Api.Products.v1.AddProduct;

public record AddProductCommand(string Name, IEnumerable<string> Category, string Description, string ImageFile, decimal Price) : ICommand;