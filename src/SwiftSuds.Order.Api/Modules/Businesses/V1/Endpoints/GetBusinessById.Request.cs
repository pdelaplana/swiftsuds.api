using System.Reflection;

namespace SwiftSuds.Order.Api.Modules.Businesses.V1.Endpoints;

public record GetBusinessByIdRequest(string Id)
{
    public static ValueTask<GetBusinessByIdRequest?> BindAsync(HttpContext httpContext, ParameterInfo parameter)
    {
        var id = httpContext.Request.RouteValues["id"];

        if (id == null)
        {
            return ValueTask.FromResult<GetBusinessByIdRequest?>(null);
        }
        return ValueTask.FromResult<GetBusinessByIdRequest?>(
            new GetBusinessByIdRequest(id.ToString()!)
        );
    }
}
