using BusModels;

namespace Services.Bus.Abstractions;

public interface ICreateOrderProducer
{
    public Task NotifyOrderCreated(OrderCreated order);
}