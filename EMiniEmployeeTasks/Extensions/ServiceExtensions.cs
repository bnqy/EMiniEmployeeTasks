using Contracts.Interfaces;
using EMiniEmployeeTasks.Repository;
using EMiniEmployeeTasks.Service;
using EMiniEmployeeTasks.Service.Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;

namespace EMiniEmployeeTasks.Extensions;

public static class ServiceExtensions
{
    public static void ConfigCors(this IServiceCollection services)
    {
        services.AddCors(opts =>
        {
            opts.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination"); 
            });
        });
    }

    public static void ConfigIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(opts =>
        {

        });

    public static void ConfigLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    public static void ConfigRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    }

    public static void ConfigServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
    }

    public static void ConfigSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(opts => 
        opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }

}
