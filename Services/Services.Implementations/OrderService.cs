using AutoMapper;
using Domain;
using Exceptions.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Services.Bus.Abstractions;
using Services.Repositories.Abstractions;
using Services.Services.Abstractions;
using Services.Services.Models.Request.Order;
using Services.Services.Models.Response;

namespace Services.Services.Implementations;

public class OrderService(
    IOrderRepository orderRepository,
    IMapper mapper,
    IValidator<CreateOrderModel> createOrderValidator,
    IValidator<DeleteOrderModel> deleteOrderValidator,
    IValidator<GetOrderByIdModel> getOrderByIdValidator,
    IValidator<GetOrdersByClientIdModel> getOrdersByClientIdValidator,
    IValidator<GetOrdersByManagerIdModel> getOrdersByManagerIdValidator,
    IValidator<UpdateOrderModel> updateManagerInOrderValidator,
    ICreateOrderProducer createOrderProducer) : IOrderService
{
    public async Task<Guid> CreateOrder(CreateOrderModel model)
    {
        var validationResult = await createOrderValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            throw new ServiceException
            {
                Title = "Validation error",
                Message = "Model validation error",
                StatusCode = StatusCodes.Status400BadRequest,
            };

        var result = await orderRepository.CreateOrderAsync(mapper.Map<Order>(model));
        
        await createOrderProducer.NotifyOrderCreated(new()
        {
            OrderId = result
        });
        
        return result;
    }
    
    public async Task<OrderModel> DeleteOrder(DeleteOrderModel model)
    {
        var validationResult = await deleteOrderValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            throw new ServiceException
            {
                Title = "Validation error",
                Message = "Model validation error",
                StatusCode = StatusCodes.Status400BadRequest,
            };
        
        var order = await orderRepository.DeleteOrderAsync(mapper.Map<Order>(model));
        var result = mapper.Map<OrderModel>(order);
        return result;
    }

    public async Task<OrderModel> GetOrderById(GetOrderByIdModel model)
    {
        var validationResult = await getOrderByIdValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            throw new ServiceException
            {
                Title = "Validation error",
                Message = "Model validation error",
                StatusCode = StatusCodes.Status400BadRequest,
            };
        
        var order = await orderRepository.GetByIdAsync(mapper.Map<Order>(model));
        var result = mapper.Map<OrderModel>(order);
        return result;
    }

    public async Task<List<OrderModel>> GetAllOrders()
    {
        var orders = await orderRepository.GetAllOrders();
        var result = mapper.Map<List<OrderModel>>(orders);
        return result;
    }
    
    public async Task<List<OrderModel>> GetOrdersByClientId(GetOrdersByClientIdModel model)
    {
        var validationResult = await getOrdersByClientIdValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            throw new ServiceException
            {
                Title = "Validation error",
                Message = "Model validation error",
                StatusCode = StatusCodes.Status400BadRequest,
            };
        
        var orders = await orderRepository.GetOrdersByClientIdAsync(mapper.Map<Order>(model));
        var result = mapper.Map<List<OrderModel>>(orders);
        return result;
    }
    
    public async Task<List<OrderModel>> GetOrdersByManagerId(GetOrdersByManagerIdModel model)
    {
        var validationResult = await getOrdersByManagerIdValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            throw new ServiceException
            {
                Title = "Validation error",
                Message = "Model validation error",
                StatusCode = StatusCodes.Status400BadRequest,
            };
        
        var orders = await orderRepository.GetOrdersByManagerIdAsync(mapper.Map<Order>(model));
        var result = mapper.Map<List<OrderModel>>(orders);
        return result;
    }
    
    public async Task<OrderModel> UpdateOrder(UpdateOrderModel model)
    {
        var validationResult = await updateManagerInOrderValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            throw new ServiceException
            {
                Title = "Validation error",
                Message = "Model validation error",
                StatusCode = StatusCodes.Status400BadRequest,
            };
        
        var order = await orderRepository.UpdateOrderAsync(mapper.Map<Order>(model));
        var result = mapper.Map<OrderModel>(order);
        return result;
    }
}