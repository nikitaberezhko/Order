using Services.Services.Models.Response;

namespace WebApi.Models.Response.Order;

public class GetOrdersByManagerIdResponse
{
    public List<OrderModel> Orders { get; set; }
}