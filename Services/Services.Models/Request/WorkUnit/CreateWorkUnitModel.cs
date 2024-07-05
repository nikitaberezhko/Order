namespace Services.Services.Models.Request.WorkUnit;

public class CreateWorkUnitModel
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public double Price { get; set; }
}