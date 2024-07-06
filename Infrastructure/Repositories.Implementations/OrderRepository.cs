using Domain;
using Exceptions.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations;

public class OrderRepository(DbContext dbContext) : IOrderRepository
{
    public async Task<Guid> CreateOrderAsync(Order model)
    {
        model.Id = Guid.NewGuid();
        model.ManagerId = null;
        model.IsDeleted = false;
        
        await dbContext.Set<Order>().AddAsync(model);
        await dbContext.SaveChangesAsync();
    
        return model.Id;
    }

    public async Task<Order> GetByIdAsync(Order model)
    {
        var order = await dbContext.Set<Order>().FirstOrDefaultAsync(x => x.Id == model.Id);
        if (order != null)
            return order;
        
        throw new DomainException
        {
            Title = "Order not found",
            Message = "Order with this id not found",
            StatusCode = StatusCodes.Status404NotFound
        };
    }

    public async Task<List<Order>> GetAllOrders()
    {
        return await dbContext.Set<Order>().ToListAsync();
    }

    public async Task<List<Order>> GetOrdersByClientIdAsync(Order model)
    {
        var orders = await dbContext.Set<Order>()
            .Where(x => x.ClientId == model.ClientId).ToListAsync();
        if(orders != null && orders.Any())
            return orders;
        
        throw new DomainException
        {
            Title = "Orders not found",
            Message = "Orders with this client id not found",
            StatusCode = StatusCodes.Status404NotFound
        };
    }

    public async Task<List<Order>> GetOrdersByManagerIdAsync(Order model)
    {
        // TODO: Check list for null
        var orders = await dbContext.Set<Order>()
            .Where(x => x.ManagerId == model.ManagerId).ToListAsync();
        if(orders != null && orders.Any())
            return orders;
        
        throw new DomainException
        {
            Title = "Orders not found",
            Message = "Orders with this manager id not found",
            StatusCode = StatusCodes.Status404NotFound
        };
    }

    public async Task<Order> UpdateOrderAsync(Order model)
    {
        var order = await dbContext.Set<Order>().FirstOrDefaultAsync(x => x.Id == model.Id);
        if (order != null)
        {
            dbContext.Entry(order).CurrentValues.SetValues(model);
            await dbContext.SaveChangesAsync();
            return order;
        }
        
        throw new DomainException
        {
            Title = "Order not found",
            Message = "Order with this id not found",
            StatusCode = StatusCodes.Status404NotFound
        };
    }

    public async Task<Order> DeleteOrderAsync(Order model)
    {
        var order = await dbContext.Set<Order>().FirstOrDefaultAsync(x => x.Id == model.Id);
        if (order != null)
        {
            order.IsDeleted = true;
            await dbContext.SaveChangesAsync();
            return order;
        }
        
        throw new DomainException
        {
            Title = "Order not found",
            Message = "Order with this id not found",
            StatusCode = StatusCodes.Status404NotFound
        };
    }
}