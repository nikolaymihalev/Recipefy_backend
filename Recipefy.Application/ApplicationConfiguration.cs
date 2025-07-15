using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Recipefy.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}