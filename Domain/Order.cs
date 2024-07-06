namespace Domain;

public class Order
{
    public Guid Id { get; set; }
    
    public Guid ClientId { get; set; }
    
    public Guid? ManagerId { get; set; }
    
    public string Model { get; set; }
    
    public string ModelProductionDate { get; set; }
    
    public virtual ICollection<WorkUnit> WorkUnits { get; set; }
    
    public bool IsDeleted { get; set; }
}