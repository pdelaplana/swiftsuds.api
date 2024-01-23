using MediatR;
namespace SwiftSuds.Order.Api.Modules.Common;

public abstract class BaseApiEndpoint
{
    public abstract Delegate AsyncHandlerDelegate();

}
public abstract class ApiEndpoint<TRequest, TResponse>: BaseApiEndpoint
{
    public abstract Task<TResponse> AsyncHandler(TRequest request, IMediator mediator);
}

public static class EndpointHandlerFactory
{
    public static Delegate CreateHandler<TEndpoint>() where TEndpoint : BaseApiEndpoint, new()
    {
        TEndpoint endpoint = new TEndpoint();
        return endpoint.AsyncHandlerDelegate();
    }
}
