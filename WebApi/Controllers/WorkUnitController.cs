using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Abstractions;
using Services.Services.Models.Request.WorkUnit;
using WebApi.Models;
using WebApi.Models.Request.WorkUnit;
using WebApi.Models.Response.WorkUnit;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/workunits")]
public class WorkUnitController(
    IWorkUnitService workUnitService,
    IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateWorkUnitResponse>>> CreateWorkUnit(
        CreateWorkUnitRequest request)
    {
        var workUnit = await workUnitService.CreateWorkUnit(mapper.Map<CreateWorkUnitModel>(request));

        var response = new CommonResponse<CreateWorkUnitResponse>
        {
            Data = new CreateWorkUnitResponse
            {
                Id = workUnit
            }
        };

        return response;
    }

    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateWorkUnitResponse>>> UpdateWorkUnit(
        UpdateWorkUnitRequest request)
    {
        var workUnit = await workUnitService.UpdateWorkUnit(mapper.Map<UpdateWorkUnitModel>(request));
        
        var response = new CommonResponse<UpdateWorkUnitResponse>
        {
            Data = new UpdateWorkUnitResponse
            {
                Id = workUnit.Id,
                Name = workUnit.Name,
                Description = workUnit.Description,
                Price = workUnit.Price
            }
        };

        return response;
    }

    [HttpDelete]
    public async Task<ActionResult<CommonResponse<DeleteWorkUnitResponse>>> DeleteWorkUnit(
        DeleteWorkUnitRequest request)
    {
        var workUnit = await workUnitService.DeleteWorkUnit(mapper.Map<DeleteWorkUnitModel>(request));
        
        var response = new CommonResponse<DeleteWorkUnitResponse>
        {
            Data = new DeleteWorkUnitResponse
            {
                Name = workUnit.Name,
                Description = workUnit.Description,
                Price = workUnit.Price
            }
        };
        
        return response;
    }
}