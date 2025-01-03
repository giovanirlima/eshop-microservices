﻿using BuildingBlock.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlock.Behaviors;

public class ValidatorBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var results = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = results.Where(r => r.Errors.Count > 0).SelectMany(r => r.Errors).ToList();

        if (failures.Count > 0)
            throw new ValidationException(failures);

        return await next();
    }
}