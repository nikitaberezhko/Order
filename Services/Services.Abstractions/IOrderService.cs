using Services.Services.Models.Request.Order;
using Services.Services.Models.Response;

namespace Services.Services.Abstractions;

public interface IOrderService
{
    public Task<Guid> CreateOrder(CreateOrderModel model);

    public Task<OrderModel> DeleteOrder(DeleteOrderModel model);

    public Task<OrderModel> GetOrderById(GetOrderByIdModel model);

    public Task<List<OrderModel>> GetAllOrders();

    public Task<List<OrderModel>> GetOrdersByClientId(GetOrdersByClientIdModel model);

    public Task<List<OrderModel>> GetOrdersByManagerId(GetOrdersByManagerIdModel model);

    public Task<OrderModel> UpdateOrder(UpdateOrderModel model);
}