using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityFramework;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<WorkUnit> WorkUnits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseLazyLoadingProxies();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().Property(x => x.Id)
            .HasColumnName("id");
        modelBuilder.Entity<Order>().Property(x => x.ClientId)
            .HasColumnName("client_id");
        modelBuilder.Entity<Order>().Property(x => x.ManagerId)
            .HasColumnName("manager_id");
        modelBuilder.Entity<Order>().Property(x => x.Model)
            .HasColumnName("model");
        modelBuilder.Entity<Order>().Property(x => x.ModelProductionDate)
            .HasColumnName("model_production_date");
        modelBuilder.Entity<Order>().Property(x => x.IsDeleted)
            .HasColumnName("is_deleted");

        modelBuilder.Entity<WorkUnit>().Property(x => x.Id)
            .HasColumnName("id");
        modelBuilder.Entity<WorkUnit>().Property(x => x.OrderId)
            .HasColumnName("order_id");
        modelBuilder.Entity<WorkUnit>().Property(x => x.Name)
            .HasColumnName("name");
        modelBuilder.Entity<WorkUnit>().Property(x => x.Description)
            .HasColumnName("description");
        modelBuilder.Entity<WorkUnit>().Property(x => x.Price)
            .HasColumnName("price");
    }
}