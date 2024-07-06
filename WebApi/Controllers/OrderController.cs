using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Abstractions;
using Services.Services.Models.Request.Order;
using WebApi.Models;
using WebApi.Models.Request.Order;
using WebApi.Models.Request.WorkUnit;
using WebApi.Models.Response.Order;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/orders/")]
[ApiVersion(1.0)]
public class OrderController(
    IOrderService orderService,
    IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateOrderResponse>>> CreateOrder(
        CreateOrderRequest request)
    {
        var order = await orderService.CreateOrder(mapper.Map<CreateOrderModel>(request));
        
        var response = new CreatedResult(nameof(CreateOrder), new CommonResponse<CreateOrderResponse>
        {
            Data = new CreateOrderResponse
            {
                Id = order
            }
        });

        return response;
    }
    
    [HttpDelete]
    public async Task<ActionResult<CommonResponse<DeleteOrderResponse>>> DeleteOrder(
        DeleteOrderRequest request)
    {
        var order = await orderService.DeleteOrder(mapper.Map<DeleteOrderModel>(request));
        
        var response = new CommonResponse<DeleteOrderResponse>
        {
            Data = new DeleteOrderResponse
            {
                ClientId = order.ClientId,
                ManagerId = order.ManagerId,
                Model = order.Model,
                ModelProductionDate = order.ModelProductionDate,
                WorkUnits = order.WorkUnits
            }
        };
        
        return response;
    }
    
    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetAllOrdersResponse>>> GetAllOrders()
    {
        var orders = await orderService.GetAllOrders();
        
        var response = new CommonResponse<GetAllOrdersResponse>
        {
            Data = new GetAllOrdersResponse
            {
                Orders = orders
            }
        };
        
        return response;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CommonResponse<GetOrderByIdResponse>>> GetOrderById(
        [FromRoute] GetOrderByIdRequest request)
    {
        var order = await orderService.GetOrderById(mapper.Map<GetOrderByIdModel>(request));
        
        var response = new CommonResponse<GetOrderByIdResponse>
        {
            Data = new GetOrderByIdResponse
            {
                ClientId = order.ClientId,
                ManagerId = order.ManagerId,
                Model = order.Model,
                ModelProductionDate = order.ModelProductionDate,
                WorkUnits = order.WorkUnits
            }
        };
        
        return response;
    }
    
    [HttpGet("clients/{clientId}")]
    public async Task<ActionResult<CommonResponse<GetOrdersByClientIdResponse>>> GetOrdersByClientId(
        [FromRoute] GetOrdersByClientIdRequest request)
    {
        var orders = await orderService.GetOrdersByClientId(mapper.Map<GetOrdersByClientIdModel>(request));
        
        var response = new CommonResponse<GetOrdersByClientIdResponse>
        {
            Data = new GetOrdersByClientIdResponse
            {
                Orders = orders
            }
        };
        
        return response;
    }
    
    [HttpGet("managers/{managerId}")]
    public async Task<ActionResult<CommonResponse<GetOrdersByManagerIdResponse>>> GetOrdersByManagerId(
        [FromRoute] GetOrdersByManagerIdRequest request)
    {
        var orders = await orderService.GetOrdersByManagerId(mapper.Map<GetOrdersByManagerIdModel>(request));
        
        var response = new CommonResponse<GetOrdersByManagerIdResponse>
        {
            Data = new GetOrdersByManagerIdResponse
            {
                Orders = orders
            }
        };
        
        return response;
    }
    
    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateOrderResponse>>> UpdateOrder(
        UpdateOrderRequest request)
    {
        var order = await orderService.UpdateOrder(mapper.Map<UpdateOrderModel>(request));
        
        var response = new CommonResponse<UpdateOrderResponse>
        {
            Data = new UpdateOrderResponse
            {
                ClientId = order.ClientId,
                ManagerId = order.ManagerId,
                Model = order.Model,
                ModelProductionDate = order.ModelProductionDate
            }
        };
        
        return response;
    }
}