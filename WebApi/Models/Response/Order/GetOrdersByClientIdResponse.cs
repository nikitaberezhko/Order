using Services.Services.Models.Response;

namespace WebApi.Models.Response.Order;

public class GetOrdersByClientIdResponse
{
    public List<OrderModel> Orders { get; set; }
}