namespace WebApi.Models.Request.Order;

public class UpdateManagerInOrderRequest
{
    public Guid Id { get; set; }
    
    public Guid ManagerId { get; set; }
}