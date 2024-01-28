using System.Reflection;

namespace SwiftSuds.Order.Api.Modules.Customers.V1.Endpoints;

public record GetCustomersRequest(int Page = 0, int Size = 100)
{
    public static ValueTask<GetCustomersRequest?> BindAsync(HttpContext httpContext, ParameterInfo parameter)
    {
        int.TryParse(httpContext.Request.Query["page"], out var page);
        int.TryParse(httpContext.Request.Query["size"], out var pageSize);

        return ValueTask.FromResult<GetCustomersRequest?>(
            new GetCustomersRequest(
                page <= 0 ? 1 : page,
                pageSize == 0 ? 10 : pageSize
            )
        );
    }
}
