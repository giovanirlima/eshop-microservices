using MediatR;
using Microsoft.Extensions.Logging;

namespace BuildingBlock.Behaviors;

public class LoggerBehavior<TRequest, TResponse>(ILogger<LoggerBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull, IRequest<TResponse> where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Request: {Name} {@Request}", typeof(TRequest).Name, request);
            throw;
        }
    }
}