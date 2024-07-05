using Services.Services.Models.Request.Order;
using Services.Services.Models.Response;

namespace Services.Repositories.Abstractions;

public interface IOrderRepository
{
    public Task<Guid> CreateOrderAsync(CreateOrderModel model);

    public Task<List<OrderModel>> GetByIdAsync(GetOrderByIdModel model);

    public Task<List<OrderModel>> GetAllOrders();
    
    public Task<List<OrderModel>> GetOrdersByClientIdAsync(GetOrdersByClientIdModel model);
    
    public Task<List<OrderModel>> GetOrdersByManagerIdAsync(GetOrdersByManagerIdModel model);
    
    public Task<OrderModel> UpdateManagerInOrderAsync(UpdateManagerInOrderModel model);
    
    public Task<OrderModel> AddManagerToOrderAsync(AddManagerToOrderModel model);
    
    public Task<OrderModel> DeleteOrderAsync(DeleteOrderModel model);
}