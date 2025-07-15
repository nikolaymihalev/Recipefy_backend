using Microsoft.Extensions.DependencyInjection;

namespace Recipefy.Web;

public static class WebConfiguration
{
    public static IServiceCollection AddWebComponents(this IServiceCollection services)
    {
        services.AddControllers();
        
        return services
            .AddEndpointsApiExplorer();
    }
}