namespace WebApi.Models.Response.Order;

public class CreateOrderResponse
{
    public Guid Id { get; set; }
    
    public Guid ClientId { get; set; }
    
    public Guid ManagerId { get; set; }
    
    public string Model { get; set; }
    
    public string ModelProductionDate { get; set; }
}