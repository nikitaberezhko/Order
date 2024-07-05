using AutoMapper;
using Services.Services.Models.Request.Order;
using Services.Services.Models.Request.WorkUnit;
using WebApi.Models.Request.Order;
using WebApi.Models.Request.WorkUnit;

namespace WebApi.Mapping;

public class ApiWorkUnitMappingProfile : Profile
{
    public ApiWorkUnitMappingProfile()
    {
        // Requests -> Request models
        CreateMap<CreateOrderRequest, CreateOrderModel>();

        CreateMap<UpdateWorkUnitRequest, UpdateWorkUnitModel>();

        CreateMap<DeleteWorkUnitRequest, DeleteWorkUnitModel>();

        
        // Response models -> Responses 
    }
}