﻿using BuildingBlock.CQRS;

namespace Api.Products.v1.UpdateProduct;

public class UpdateProductCommand : ICommand
{
    internal Guid Id { get; private set; }
    public string Name { get; set; } = default!;
    public List<string> Category { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public decimal Price { get; set; }

    public UpdateProductCommand SetIdProperty(Guid id)
    {
        Id = id;
        return this;
    }
}