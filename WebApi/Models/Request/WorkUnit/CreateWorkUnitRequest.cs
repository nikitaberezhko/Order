namespace WebApi.Models.Request.WorkUnit;

public class CreateWorkUnitRequest
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public double Price { get; set; }
}