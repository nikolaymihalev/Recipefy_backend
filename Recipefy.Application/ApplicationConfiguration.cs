using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Recipefy.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        return AddMediatR(services);
    }

    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
        );

        return services;
    }
}