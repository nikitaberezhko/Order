using BusModels;
using Domain;
using MassTransit;
using Services.Bus.Abstractions;

namespace Infrastructure.Bus.Implementations.Producers;

public class CreateOrderProducer(IPublishEndpoint publishEndpoint) 
    : ICreateOrderProducer
{
    public async Task NotifyOrderCreated(OrderCreated order) =>
        await publishEndpoint.Publish<OrderCreated>(order);
}