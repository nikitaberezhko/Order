namespace Services.Services.Models.Request.WorkUnit;

public class UpdateWorkUnitModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public double Price { get; set; }
}