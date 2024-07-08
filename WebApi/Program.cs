using Infrastructure.Bus.Implementations.Producers;
using Infrastructure.Repositories.Implementations;
using Infrastructure.Settings;
using Services.Bus.Abstractions;
using Services.Repositories.Abstractions;
using Services.Services.Abstractions;
using Services.Services.Implementations;
using WebApi.Extensions;
using WebApi.Middlewares;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;

        services.Configure<RmqSettings>(builder.Configuration.GetSection("RmqSettings"));
        
        services.AddControllers();
        
        // Extensions
        services.ConfigureApiVersioning();
        services.ConfigureContext(builder.Configuration.GetConnectionString(
            "DefaultConnectionString")!);
        services.ConfigureValidators();
        services.ConfigureAutoMapper();
        services.ConfigureMassTransit(builder.Configuration);

        services.AddScoped<ICreateOrderProducer, CreateOrderProducer>();

        // Repositories
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IWorkUnitRepository, WorkUnitRepository>();
        
        // Services
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IWorkUnitService, WorkUnitService>();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddTransient<ExceptionHandlerMiddleware>();

        var app = builder.Build();

        app.UseMiddleware<ExceptionHandlerMiddleware>();
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}