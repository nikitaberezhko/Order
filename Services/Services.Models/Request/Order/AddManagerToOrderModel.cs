namespace Services.Services.Models.Request.Order;

public class AddManagerToOrderModel
{
    public Guid Id { get; set; }
    
    public Guid ManagerId { get; set; }
}