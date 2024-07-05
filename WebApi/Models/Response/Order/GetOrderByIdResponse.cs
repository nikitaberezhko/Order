using Services.Services.Models.Response;

namespace WebApi.Models.Response.Order;

public class GetOrderByIdResponse
{
    public Guid Id { get; set; }
    
    public Guid ClientId { get; set; }
    
    public Guid ManagerId { get; set; }
    
    public string Model { get; set; }
    
    public string ModelProductionDate { get; set; }
    
    public List<WorkUnitModel> WorkUnits { get; set; }
    
    // TODO: Refactor Response models
}