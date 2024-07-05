namespace WebApi.Models.Request.Order;

public class AddManagerToOrderRequest
{
    public Guid Id { get; set; }
    
    public Guid ManagerId { get; set; }
}