using DDD.Example.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace DDD.Example.Application.Common.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        if (request is not Command command)
        {
            return await next();
        }

        var validationResult = command.TryValidate();
        if (!validationResult.IsError)
        {
            return await next();
        }

        return (dynamic)validationResult.Errors.ConvertAll(error => Error.Validation(error.Code, error.Description));
    }
}