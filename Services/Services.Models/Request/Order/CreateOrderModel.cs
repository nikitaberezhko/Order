namespace Services.Services.Models.Request.Order;

public class CreateOrderModel
{
    public Guid Id { get; set; }
    
    public Guid ClientId { get; set; }
    
    public string Model { get; set; }
    
    public string ModelProductionDate { get; set; }
}