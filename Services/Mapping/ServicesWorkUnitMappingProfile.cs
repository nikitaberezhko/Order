using AutoMapper;
using Domain;
using Services.Services.Models.Request.WorkUnit;
using Services.Services.Models.Response;

namespace Services.Mapping;

public class ServicesWorkUnitMappingProfile : Profile
{
    public ServicesWorkUnitMappingProfile()
    {
        // Request models -> Domain
        CreateMap<CreateWorkUnitModel, WorkUnit>()
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.Description, map => map.MapFrom(c => c.Description))
            .ForMember(d => d.Price, map => map.MapFrom(c => c.Price));
        

        CreateMap<UpdateWorkUnitModel, WorkUnit>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.Description, map => map.MapFrom(c => c.Description))
            .ForMember(d => d.Price, map => map.MapFrom(c => c.Price));

        CreateMap<DeleteWorkUnitModel, WorkUnit>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.Ignore())
            .ForMember(d => d.Description, map => map.Ignore())
            .ForMember(d => d.Price, map => map.Ignore());
        
        
        // Domain -> Response models
        CreateMap<WorkUnit, WorkUnitModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.Name, map => map.MapFrom(c => c.Name))
            .ForMember(d => d.Description, map => map.MapFrom(c => c.Description))
            .ForMember(d => d.Price, map => map.MapFrom(c => c.Price));
    }
}