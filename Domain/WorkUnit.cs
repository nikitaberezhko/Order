namespace Domain;

public class WorkUnit
{
    public Guid Id { get; set; }
    
    public Guid OrderId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public double Price { get; set; }
}