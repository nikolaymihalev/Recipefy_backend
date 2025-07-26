using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Recipefy.Application.Contracts.Services;
using Recipefy.Application.Features.External.Spoonacular.Models;

namespace Recipefy.Infrastructure.External.Services;

public class SpoonacularService : ISpoonacularService
{
    private readonly string _baseUrl;
    private readonly string _apiKey;
    
    private readonly HttpClient _httpClient;

    public SpoonacularService(IConfiguration configuration)
    {
        _baseUrl = configuration["Spoonacular:BaseUrl"];
        _apiKey = configuration["Spoonacular:ApiKey"];
        
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(_baseUrl)
        };
    }
    
    public async Task<GetRandorRecipesOutputModel?> GetRandormRecipesAsync(int? number = 100, bool? includeNutrion = true, CancellationToken token = default)
    {
        const int MaxRecipesCount = 100;
        
        var endpoint = "/recipes/random";
        
        number = number > MaxRecipesCount ? MaxRecipesCount : number;
        
        var query = $"number={number}&includeNutrition={includeNutrion}";
        
        return await GetAsync<GetRandorRecipesOutputModel>(endpoint, query, token);
    }

    private async Task<T?> GetAsync<T>(string endpoint, string query, CancellationToken token)
    {
        var url = $"{endpoint}?apiKey={_apiKey}&{query}";
        
        var response = await _httpClient.GetAsync(url, token);

        return await response.Content.ReadFromJsonAsync<T>(token);
    }
}