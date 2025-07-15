using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipefy.Infrastructure.Persistence;

namespace Recipefy.Infrastructure;

public static class InfrastructureConfiguration
{
    private const string DatabaseKey = "RecipefyDb";
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return AddDbContext(services,configuration);
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));
        
        return services;
    }
}