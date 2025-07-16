using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Recipefy.Application.Contracts.Services;
using Recipefy.Application.Features.External.MealDB.Commands.SyncWithAllCategories;
using Recipefy.Application.Features.External.MealDB.Commands.SyncWithAllIngredients;

namespace Recipefy.Infrastructure.External.Services;

public class MealDbService : IMealDbService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    
    public MealDbService(
        IConfiguration configuration)
    {
        _baseUrl = configuration["TheMealDB:BaseUrl"];
        
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(_baseUrl)
        };
    }
    
    public async Task<GetIngredientsOutputModel?> GetAllIngredientsAsync(CancellationToken cancellationToken = default)
    {
        var query = "/list.php?i=list";
        
        return await GetAsync<GetIngredientsOutputModel>(query, cancellationToken);
    }

    public async Task<GetCategoryOutputModel?> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var query = "/list.php?c=list";
        
        return await GetAsync<GetCategoryOutputModel>(query, cancellationToken);
    }

    private async Task<T?> GetAsync<T>(string query, CancellationToken cancellationToken)
        => await _httpClient.GetFromJsonAsync<T>(query, cancellationToken);
}