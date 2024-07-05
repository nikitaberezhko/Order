using Services.Services.Models.Response;

namespace WebApi.Models.Response.Order;

public class GetOrdersByClientIdResponse
{
    List<OrderModel> Orders { get; set; }
}