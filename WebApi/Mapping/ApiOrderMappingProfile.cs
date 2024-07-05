using AutoMapper;
using Services.Services.Models.Request.Order;
using WebApi.Models.Request.Order;

namespace WebApi.Mapping;

public class ApiOrderMappingProfile : Profile
{
    public ApiOrderMappingProfile()
    {
        // Requests -> Request models
        CreateMap<CreateOrderRequest, CreateOrderModel>();

        CreateMap<DeleteOrderRequest, DeleteOrderModel>();

        CreateMap<GetOrderByIdRequest, GetOrderByIdModel>();

        CreateMap<AddManagerToOrderRequest, AddManagerToOrderModel>();
        
        CreateMap<UpdateManagerInOrderRequest, UpdateManagerInOrderModel>();
        
        CreateMap<GetOrdersByClientIdRequest, GetOrdersByClientIdModel>();
        
        CreateMap<GetOrdersByManagerIdRequest, GetOrdersByManagerIdModel>();
        

        // Response models -> Responses 
    }
}