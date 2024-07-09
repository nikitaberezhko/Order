using AutoMapper;
using Services.Services.Models.Request.WorkUnit;
using Services.Services.Models.Response;
using WebApi.Models.Request.WorkUnit;
using WebApi.Models.Response;
using WebApi.Models.Response.WorkUnit;

namespace WebApi.Mapping;

public class ApiWorkUnitMappingProfile : Profile
{
    public ApiWorkUnitMappingProfile()
    {
        // Requests -> Request models
        CreateMap<CreateWorkUnitRequest, CreateWorkUnitModel>()
            .ForMember(d => d.OrderId, map => map.MapFrom(c => c.OrderId))
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.Description, map => map.MapFrom(c => c.Description))
            .ForMember(d => d.Price, map => map.MapFrom(c => c.Price));

        CreateMap<UpdateWorkUnitRequest, UpdateWorkUnitModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.Description, map => map.MapFrom(c => c.Description))
            .ForMember(d => d.Price, map => map.MapFrom(c => c.Price));


        CreateMap<DeleteWorkUnitRequest, DeleteWorkUnitModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));

        
        // Response models -> Responses
        CreateMap<WorkUnitModel, CreateWorkUnitResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));
        
        CreateMap<WorkUnitModel, UpdateWorkUnitResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.Description, map => map.MapFrom(c => c.Description))
            .ForMember(d => d.Price, map => map.MapFrom(c => c.Price));
        
        CreateMap<WorkUnitModel, DeleteWorkUnitResponse>()
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.Description, map => map.MapFrom(c => c.Description))
            .ForMember(d => d.Price, map => map.MapFrom(c => c.Price));
        
        CreateMap<WorkUnitModel, WorkUnitData>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.Description, map => map.MapFrom(c => c.Description))
            .ForMember(d => d.Price, map => map.MapFrom(c => c.Price));
    }
}