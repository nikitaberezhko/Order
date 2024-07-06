namespace Services.Services.Models.Request.Order;

public class UpdateOrderModel
{
    public Guid Id { get; set; }
    
    public Guid? ManagerId { get; set; }
    
    public string Model { get; set; }
    
    public string ModelProductionDate { get; set; }
}