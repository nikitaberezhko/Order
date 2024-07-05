using Services.Services.Models.Response;

namespace WebApi.Models.Response.Order;

public class GetAllOrdersResponse
{
    private List<OrderModel> Orders { get; set; }
}