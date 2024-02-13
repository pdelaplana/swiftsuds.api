using System.Reflection;

namespace SwiftSuds.Order.Api.Modules.Businesses.V1.Endpoints;

public record GetBusinessesRequest(int Page = 0, int Size = 100)
{
    public static ValueTask<GetBusinessesRequest?> BindAsync(HttpContext httpContext, ParameterInfo parameter)
    {
        int.TryParse(httpContext.Request.Query["page"], out var page);
        int.TryParse(httpContext.Request.Query["size"], out var pageSize);

        return ValueTask.FromResult<GetBusinessesRequest?>(
            new GetBusinessesRequest(
                page <= 0 ? 1 : page,
                pageSize == 0 ? 10 : pageSize
            )
        );
    }
}
