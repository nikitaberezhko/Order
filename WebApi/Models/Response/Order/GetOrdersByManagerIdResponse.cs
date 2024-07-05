using Services.Services.Models.Response;

namespace WebApi.Models.Response.Order;

public class GetOrdersByManagerIdResponse
{
    List<OrderModel> Orders { get; set; }
}