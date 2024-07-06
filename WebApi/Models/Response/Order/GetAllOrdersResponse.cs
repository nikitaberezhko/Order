using Services.Services.Models.Response;

namespace WebApi.Models.Response.Order;

public class GetAllOrdersResponse
{
    public List<OrderModel> Orders { get; set; }
}