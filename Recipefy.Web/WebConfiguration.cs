using Microsoft.Extensions.DependencyInjection;

namespace Recipefy.Web;

public static class WebConfiguration
{
    public static IServiceCollection AddWebComponents(this IServiceCollection services)
    {
        services.AddControllers();
        
        return services.AddEndpointsApiExplorer()
            .AddCustomCors();
    }

    private static IServiceCollection AddCustomCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        
        return services;
    }
}