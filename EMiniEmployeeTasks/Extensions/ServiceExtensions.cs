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
}
