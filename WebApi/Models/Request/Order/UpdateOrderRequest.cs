namespace WebApi.Models.Request.Order;

public class UpdateOrderRequest
{
    public Guid Id { get; set; }
    
    public Guid? ManagerId { get; set; }
    
    public string Model { get; set; }
    
    public DateTime ModelProductionDate { get; set; }
}