using SwiftSuds.Domain.ValueObjects;
using SwiftSuds.Order.Api.Modules.Customers.V1.Models;

namespace SwiftSuds.Order.Api.Modules.Customers.V1.Endpoints;

public record GetCustomersResponse(IList<CustomerInfo> Customers, int Page, int Size);