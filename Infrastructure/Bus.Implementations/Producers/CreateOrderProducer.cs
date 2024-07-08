using BusModels;
using MassTransit;
using Microsoft.Extensions.Logging;
using Services.Bus.Abstractions;

namespace Infrastructure.Bus.Implementations.Producers;

public class CreateOrderProducer(IPublishEndpoint publishEndpoint,
    ILogger<CreateOrderProducer> logger) 
    : ICreateOrderProducer
{
    public async Task NotifyOrderCreated(OrderCreated order)
    {
        logger.LogInformation("Order created with id: {id}", order.OrderId);
        await publishEndpoint.Publish(order);
    }
}