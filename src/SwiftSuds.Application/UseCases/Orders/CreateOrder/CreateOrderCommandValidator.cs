using FluentValidation;


namespace SwiftSuds.Application.UseCases.Orders.CreateOrder;
internal class CreateOrderCommandValidator: AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(command => command.PickupAddress.StreetAddress1).NotEmpty();
        RuleFor(command => command.PickupAddress.City).NotEmpty();

        RuleFor(command => command.DeliveryAddress.StreetAddress1).NotEmpty();
        RuleFor(command => command.DeliveryAddress.City).NotEmpty();

        RuleFor(command => command.ScheduledPickupDateTimeEnd).NotEmpty();
        RuleFor(command => command.ScheduledPickupDateTimeStart).NotEmpty()
            .LessThanOrEqualTo(command => command.ScheduledPickupDateTimeEnd);

        RuleFor(command => command.ScheduledDeliveryDateTimeEnd).NotEmpty();
        RuleFor(command => command.ScheduledDeliveryDateTimeStart).NotEmpty()
            .LessThanOrEqualTo(command => command.ScheduledDeliveryDateTimeEnd);

        RuleForEach(command => command.Items).SetValidator(new OrderItemValidator());
        RuleForEach(command => command.Services).SetValidator(new OrderServiceValidator());
    }
}

internal class OrderItemValidator : AbstractValidator<CreateOrderCommand.OrderItem>
{
    public OrderItemValidator()
    {
        RuleFor(item => item.Item).NotNull().MaximumLength(60);
        RuleFor(item => item.Quantity).GreaterThanOrEqualTo(1);

    }
}

internal class OrderServiceValidator : AbstractValidator<CreateOrderCommand.OrderService>
{
    public OrderServiceValidator()
    {
        RuleFor(service => service.Quantity).GreaterThanOrEqualTo(1);
    }
}

