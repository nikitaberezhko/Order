using Services.Services.Models.Request.WorkUnit;
using Services.Services.Models.Response;

namespace Services.Services.Abstractions;

public interface IWorkUnitService
{
    public Task<Guid> CreateWorkUnit(CreateWorkUnitModel model);

    public Task<WorkUnitModel> UpdateWorkUnit(UpdateWorkUnitModel model);

    public Task<WorkUnitModel> DeleteWorkUnit(DeleteWorkUnitModel model);
}