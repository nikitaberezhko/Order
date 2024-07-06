using Domain;

namespace Services.Repositories.Abstractions;

public interface IOrderRepository
{
    public Task<Guid> CreateOrderAsync(Order model);

    public Task<Order> GetByIdAsync(Order model);

    public Task<List<Order>> GetAllOrders();
    
    public Task<List<Order>> GetOrdersByClientIdAsync(Order model);
    
    public Task<List<Order>> GetOrdersByManagerIdAsync(Order model);
    
    public Task<Order> UpdateOrderAsync(Order model);
    
    public Task<Order> DeleteOrderAsync(Order model);
}