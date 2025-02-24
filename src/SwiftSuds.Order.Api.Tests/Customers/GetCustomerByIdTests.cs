﻿using System.Net;

namespace SwiftSuds.Order.Api.Tests.Customers;
public class GetCustomerByIdTests
{
    private const string BaseUrl = $"/api/v1/customers";

    [Fact]
    public async Task GetCustomerById_Should_ReturnCustomer()
    {
        // arrange
        var application = new OrderApiTestApplication();

        // act
        using var client = application.CreateClient();

        var response = await client.GetAsync(BaseUrl + "/" + Guid.NewGuid());

        // assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }
}
