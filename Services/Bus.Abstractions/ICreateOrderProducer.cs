using BusModels;
using Domain;

namespace Services.Bus.Abstractions;

public interface ICreateOrderProducer
{
    public Task NotifyOrderCreated(OrderCreated order);
}