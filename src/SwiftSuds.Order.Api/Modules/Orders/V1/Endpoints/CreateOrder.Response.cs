namespace SwiftSuds.Order.Api.Modules.Orders.V1.Endpoints;

public record CreateOrderResponse(Guid OrderId, DateTime OrderDate, decimal TotalPrice);

