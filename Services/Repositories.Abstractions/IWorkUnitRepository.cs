using Services.Services.Models.Request.WorkUnit;
using Services.Services.Models.Response;

namespace Services.Repositories.Abstractions;

public interface IWorkUnitRepository
{
    public Task<Guid> CreateWorkUnitAsync(CreateWorkUnitModel model);
    
    public Task<WorkUnitModel> UpdateWorkUnitAsync(UpdateWorkUnitModel model);
    
    public Task<WorkUnitModel> RemoveWorkUnitAsync(DeleteWorkUnitModel model);
}