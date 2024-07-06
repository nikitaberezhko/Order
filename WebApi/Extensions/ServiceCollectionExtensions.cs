using Asp.Versioning;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;
using Services.Mapping;
using Services.Services.Models.Request.Order;
using Services.Services.Models.Request.WorkUnit;
using Services.Validators.Order;
using Services.Validators.WorkUnit;
using WebApi.Mapping;

namespace WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureApiVersioning(
        this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
    
    public static IServiceCollection ConfigureContext(this IServiceCollection services, 
        string connectionString)
    {
        services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<DbContext, DataContext>();
        return services;
    }
    
    public static IServiceCollection ConfigureValidators(
        this IServiceCollection services)
    {
        // Order models validators
        services.AddScoped<IValidator<CreateOrderModel>, CreateOrderValidator>();
        services.AddScoped<IValidator<DeleteOrderModel>, DeleteOrderValidator>();
        services.AddScoped<IValidator<GetOrderByIdModel>, GetOrderByIdValidator>();
        services.AddScoped<IValidator<GetOrdersByClientIdModel>, GetOrdersByClientIdValidator>();
        services.AddScoped<IValidator<GetOrdersByManagerIdModel>, GetOrdersByManagerIdValidator>();
        services.AddScoped<IValidator<UpdateOrderModel>, UpdateOrderValidator>();

        // WorkUnit models validators
        services.AddScoped<IValidator<CreateWorkUnitModel>, CreateWorkUnitValidator>();
        services.AddScoped<IValidator<DeleteWorkUnitModel>, DeleteWorkUnitValidator>();
        services.AddScoped<IValidator<UpdateWorkUnitModel>, UpdateWorkUnitValidator>();
        return services;
    }
    
    public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(ServicesOrderMappingProfile),
            typeof(ServicesWorkUnitMappingProfile),
            typeof(ApiOrderMappingProfile),
            typeof(ApiWorkUnitMappingProfile));
        
        return services;
    }
}