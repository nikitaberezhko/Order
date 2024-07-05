using AutoMapper;
using Domain;
using Services.Services.Models.Request.Order;
using Services.Services.Models.Request.WorkUnit;
using Services.Services.Models.Response;

namespace Services.Mapping;

public class ServicesOrderMappingProfile : Profile
{
    public ServicesOrderMappingProfile()
    {
        // Request models -> Domain
        CreateMap<CreateOrderModel, Order>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.ClientId, map => map.MapFrom(c => c.ClientId))
            .ForMember(d => d.Model, map => map.MapFrom(c => c.Model))
            .ForMember(d => d.ModelProductionDate, map => map.MapFrom(c => c.ModelProductionDate))
            .ForMember(d => d.ManagerId, map => map.Ignore())
            .ForMember(d => d.WorkUnits, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());
        
        CreateMap<DeleteOrderModel, Order>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.ClientId, map => map.Ignore())
            .ForMember(d => d.Model, map => map.Ignore())
            .ForMember(d => d.ModelProductionDate, map => map.Ignore())
            .ForMember(d => d.ManagerId, map => map.Ignore())
            .ForMember(d => d.WorkUnits, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());
        
        CreateMap<GetOrderByIdModel, Order>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.ClientId, map => map.Ignore())
            .ForMember(d => d.Model, map => map.Ignore())
            .ForMember(d => d.ModelProductionDate, map => map.Ignore())
            .ForMember(d => d.ManagerId, map => map.Ignore())
            .ForMember(d => d.WorkUnits, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());
        
        CreateMap<AddManagerToOrderModel, Order>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.ManagerId, map => map.MapFrom(c => c.ManagerId))
            .ForMember(d => d.ClientId, map => map.Ignore())
            .ForMember(d => d.Model, map => map.Ignore())
            .ForMember(d => d.ModelProductionDate, map => map.Ignore())
            .ForMember(d => d.WorkUnits, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());
        
        CreateMap<UpdateManagerInOrderModel, Order>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.ManagerId, map => map.MapFrom(c => c.ManagerId))
            .ForMember(d => d.ClientId, map => map.Ignore())
            .ForMember(d => d.Model, map => map.Ignore())
            .ForMember(d => d.ModelProductionDate, map => map.Ignore())
            .ForMember(d => d.WorkUnits, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());

        CreateMap<GetOrdersByClientIdModel, Order>()
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.ManagerId, map => map.Ignore())
            .ForMember(d => d.ClientId, map => map.MapFrom(c => c.ClientId))
            .ForMember(d => d.Model, map => map.Ignore())
            .ForMember(d => d.ModelProductionDate, map => map.Ignore())
            .ForMember(d => d.WorkUnits, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());

        CreateMap<GetOrdersByManagerIdModel, Order>()
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.ManagerId, map => map.MapFrom(c => c.ManagerId))
            .ForMember(d => d.ClientId, map => map.Ignore())
            .ForMember(d => d.Model, map => map.Ignore())
            .ForMember(d => d.ModelProductionDate, map => map.Ignore())
            .ForMember(d => d.WorkUnits, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());
        
        
        // Domain -> Response models
        CreateMap<Order, OrderModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id))
            .ForMember(d => d.ClientId, map => map.MapFrom(c => c.ClientId))
            .ForMember(d => d.ManagerId, map => map.MapFrom(c => c.ManagerId))
            .ForMember(d => d.Model, map => map.MapFrom(c => c.Model))
            .ForMember(d => d.ModelProductionDate, map => map.MapFrom(c => c.ModelProductionDate))
            .ForMember(d => d.WorkUnitModels, map => map.MapFrom(c => c.WorkUnits));
    }
}