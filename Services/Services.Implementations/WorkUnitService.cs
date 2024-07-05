using AutoMapper;
using Domain;
using Exceptions.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Services.Repositories.Abstractions;
using Services.Services.Models.Request.Order;
using Services.Services.Models.Request.WorkUnit;
using Services.Services.Models.Response;

namespace Services.Services.Implementations;

public class WorkUnitService(
    IWorkUnitRepository workUnitRepository,
    IMapper mapper,
    IValidator<CreateWorkUnitModel> createWorkUnitValidator,
    IValidator<UpdateWorkUnitModel> updateWorkUnitValidator,
    IValidator<DeleteWorkUnitModel> deleteWorkUnitValidator)
{
    public async Task<Guid> CreateWorkUnit(CreateWorkUnitModel model)
    {
        var validationResult = await createWorkUnitValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            throw new ServiceException
            {
                Title = "Validation error",
                Message = "Model validation error",
                StatusCode = StatusCodes.Status400BadRequest,
            };
        
        var id = await workUnitRepository.CreateWorkUnitAsync(mapper.Map<WorkUnit>(model));
        return id;
    }

    public async Task<WorkUnitModel> UpdateWorkUnit(UpdateWorkUnitModel model)
    {
        var validationResult = await updateWorkUnitValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            throw new ServiceException
            {
                Title = "Validation error",
                Message = "Model validation error",
                StatusCode = StatusCodes.Status400BadRequest,
            };
        
        var workUnit =await workUnitRepository.UpdateWorkUnitAsync(mapper.Map<WorkUnit>(model));
        var result = mapper.Map<WorkUnitModel>(workUnit);
        return result;
    }
    
    public async Task<WorkUnitModel> DeleteWorkUnit(DeleteWorkUnitModel model)
    {
        var validationResult = await deleteWorkUnitValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
            throw new ServiceException
            {
                Title = "Validation error",
                Message = "Model validation error",
                StatusCode = StatusCodes.Status400BadRequest,
            };
        
        var workUnit = await workUnitRepository.DeleteWorkUnitAsync(mapper.Map<WorkUnit>(model));
        var result = mapper.Map<WorkUnitModel>(workUnit);
        return result;
    }
}