using Domain;
using Exceptions.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations;

public class WorkUnitRepository(DbContext dbContext) : IWorkUnitRepository
{
    public async Task<Guid> CreateWorkUnitAsync(WorkUnit model)
    {
        model.Id = Guid.NewGuid();
        
        await dbContext.Set<WorkUnit>().AddAsync(model);
        await dbContext.SaveChangesAsync();
    
        return model.Id;
    }

    public async Task<WorkUnit> UpdateWorkUnitAsync(WorkUnit model)
    {
        var workUnit = await dbContext.Set<WorkUnit>().FirstOrDefaultAsync(x => x.Id == model.Id);
        if (workUnit != null)
        {
            dbContext.Entry(workUnit).CurrentValues.SetValues(model);
            await dbContext.SaveChangesAsync();
            
            return workUnit;
        }

        throw new DomainException
        {
            Title = "Work unit not found",
            Message = "Work unit with this id not found",
            StatusCode = StatusCodes.Status404NotFound
        };
    }

    public async Task<WorkUnit> DeleteWorkUnitAsync(WorkUnit model)
    {
        var workUnit = await dbContext.Set<WorkUnit>().FirstOrDefaultAsync(x => x.Id == model.Id);
        if (workUnit != null)
        {
            dbContext.Set<WorkUnit>().Remove(workUnit);
            await dbContext.SaveChangesAsync();
            
            return workUnit;
        }
        
        throw new DomainException
        {
            Title = "Work unit not found",
            Message = "Work unit with this id not found",
            StatusCode = StatusCodes.Status404NotFound
        };
    }
}