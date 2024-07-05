namespace Services.Services.Models.Response;

public class OrderModel
{
    public Guid Id { get; set; }
    
    public Guid ClientId { get; set; }
    
    public Guid ManagerId { get; set; }
    
    public string Model { get; set; }
    
    public string ModelProductionDate { get; set; }
    
    public List<WorkUnitModel> WorkUnitModels { get; set; }
}