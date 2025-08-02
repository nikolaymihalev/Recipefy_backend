using Microsoft.Extensions.Configuration;
using Recipefy.Application.Contracts.Requesters;
using Recipefy.Application.Features.External.Spoonacular.Models;
using Recipefy.Application.Requesters;
using Recipefy.Application.Utility.Helpers;

namespace Recipefy.Infrastructure.External.Requesters;

public class SpoonacularRequester : BaseRequester, ISpoonacularRequester
{
    private readonly string _apiKey;
    
    public SpoonacularRequester(IConfiguration configuration)
    {
        base.BaseUrl = configuration["Spoonacular:BaseUrl"];
        _apiKey = configuration["Spoonacular:ApiKey"];
    }
    
    public async Task<GetRandorRecipesOutputModel?> GetRandormRecipesAsync(int? number, bool? includeNutrion, CancellationToken token = default)
    {
        const int MaxRecipesCount = 100;
        
        var endpoint = "/recipes/random";
        
        number = number > MaxRecipesCount ? MaxRecipesCount : number;
        
        var query = $"number={number}&includeNutrition={includeNutrion}";

        return await base.GetAsync<GetRandorRecipesOutputModel>(SpoonacularHelper.GetUrl(endpoint, query, _apiKey), token);
    }
}