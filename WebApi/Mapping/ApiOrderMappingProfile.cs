using AutoMapper;
using Services.Services.Models.Request.Order;
using Services.Services.Models.Response;
using WebApi.Models.Request.Order;
using WebApi.Models.Response.Order;

namespace WebApi.Mapping;

public class ApiOrderMappingProfile : Profile
{
    public ApiOrderMappingProfile()
    {
        // Requests -> Request models
        CreateMap<CreateOrderRequest, CreateOrderModel>()
            .ForMember(d => d.ClientId, map => map.MapFrom(c => c.ClientId))
            .ForMember(d => d.Model, map => map.MapFrom(c => c.Model))
            .ForMember(d => d.ModelProductionDate, map => map.MapFrom(c => c.ModelProductionDate));

        CreateMap<DeleteOrderRequest, DeleteOrderModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));

        CreateMap<GetOrderByIdRequest, GetOrderByIdModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));
        
        CreateMap<GetOrdersByClientIdRequest, GetOrdersByClientIdModel>()
            .ForMember(d => d.ClientId, map => map.MapFrom(c => c.ClientId));

        CreateMap<GetOrdersByManagerIdRequest, GetOrdersByManagerIdModel>()
            .ForMember(d => d.ManagerId, map => map.MapFrom(c => c.ManagerId));
        
        CreateMap<UpdateOrderRequest, UpdateOrderModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.ManagerId, map => map.MapFrom(c => c.ManagerId))
            .ForMember(d => d.Model, map => map.MapFrom(c => c.Model))
            .ForMember(d => d.ModelProductionDate, map => map.MapFrom(c => c.ModelProductionDate));
        

        // Response models -> Responses 
        CreateMap<OrderModel, CreateOrderResponse>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));
        
        CreateMap<OrderModel, DeleteOrderResponse>()
            .ForMember(d => d.ClientId, map => map.MapFrom(c => c.ClientId))
            .ForMember(d => d.ManagerId, map => map.MapFrom(c => c.ManagerId))
            .ForMember(d => d.Model, map => map.MapFrom(c => c.Model))
            .ForMember(d => d.ModelProductionDate, map => map.MapFrom(c => c.ModelProductionDate))
            .ForMember(d => d.WorkUnits, map => map.MapFrom(c => c.WorkUnits));
        
        CreateMap<OrderModel, GetOrderByIdResponse>()
            .ForMember(d => d.ClientId, map => map.MapFrom(c => c.ClientId))
            .ForMember(d => d.ManagerId, map => map.MapFrom(c => c.ManagerId))
            .ForMember(d => d.Model, map => map.MapFrom(c => c.Model))
            .ForMember(d => d.ModelProductionDate, map => map.MapFrom(c => c.ModelProductionDate))
            .ForMember(d => d.WorkUnits, map => map.MapFrom(c => c.WorkUnits));

        CreateMap<OrderModel, UpdateOrderResponse>()
            .ForMember(d => d.ClientId, map => map.MapFrom(c => c.ClientId))
            .ForMember(d => d.ManagerId, map => map.MapFrom(c => c.ManagerId))
            .ForMember(d => d.Model, map => map.MapFrom(c => c.Model))
            .ForMember(d => d.ModelProductionDate, map => map.MapFrom(c => c.ModelProductionDate));
    }
}