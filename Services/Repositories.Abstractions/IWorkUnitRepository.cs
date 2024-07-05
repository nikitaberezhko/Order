using Domain;

namespace Services.Repositories.Abstractions;

public interface IWorkUnitRepository
{
    public Task<Guid> CreateWorkUnitAsync(WorkUnit model);
    
    public Task<WorkUnit> UpdateWorkUnitAsync(WorkUnit model);
    
    public Task<WorkUnit> DeleteWorkUnitAsync(WorkUnit model);
}