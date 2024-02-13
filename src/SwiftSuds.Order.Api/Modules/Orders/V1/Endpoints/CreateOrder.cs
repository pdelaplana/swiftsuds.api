using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SwiftSuds.Application.UseCases.Orders.CreateOrder;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Entities.BusinessServices;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Errors;
using SwiftSuds.Order.Api.Modules.Common;

namespace SwiftSuds.Order.Api.Modules.Orders.V1.Endpoints;

public class CreateOrder : ApiEndpoint<CreateOrderRequest, Results<Created<CreateOrderResponse>, ValidationProblem>>
{
    public override async Task<Results<Created<CreateOrderResponse>, ValidationProblem>> AsyncHandler(CreateOrderRequest request, IMediator mediator, ILogger<CreateOrderRequest> logger)
    {
        logger.LogInformation("Invoking endpoint '{endpoint}' with '{req}'",
            nameof(CreateOrder),
            request);


        var command = new CreateOrderCommand
        {
            BusinessId = new BusinessId(request.BusinessId),
            CurrencySymbol = request.CurrencySymbol,
            CustomerId = new CustomerId(request.CustomerId),
            DeliveryAddress = request.DeliveryAddress,
            IsPaid = request.IsPaid,
            OrderDate = DateTime.UtcNow,
            PickupAddress = request.PickupAddress,
            ScheduledDeliveryDateTimeStart = request.ScheduledDeliveryDateTimeStart,
            ScheduledDeliveryDateTimeEnd = request.ScheduledDeliveryDateTimeEnd,
            ScheduledPickupDateTimeStart = request.ScheduledPickupDateTimeStart,
            ScheduledPickupDateTimeEnd = request.ScheduledPickupDateTimeEnd,
            Items = request.Items.Select(i => new CreateOrderCommand.OrderItem(i.Item, i.Quantity)).ToList(),
            Services = request.Services.Select(s => new CreateOrderCommand.OrderService(new BusinessServiceId(s.BusinessServiceId), s.Quantity, s.Price)).ToList()
        };
        var result = await mediator.Send(command);

        return result.Match<Results<Created<CreateOrderResponse>, ValidationProblem>>(
            order => {
                var response = new CreateOrderResponse(order.OrderId.Value, order.OrderDate, order.AmountDue.Amount);
                return TypedResults.Created($"Created", response);
            },
            error => TypedResults.ValidationProblem(((ValidationError)error).ValidationErrors)
            );

    }

    public override Delegate AsyncHandlerDelegate()
    {
        return AsyncHandler;
    }
}
