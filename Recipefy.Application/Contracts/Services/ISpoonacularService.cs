using Recipefy.Application.Contracts.Common;
using Recipefy.Application.Features.External.Spoonacular.Models;

namespace Recipefy.Application.Contracts.Services;

public interface ISpoonacularService : IScopedService
{
    Task<GetRandorRecipesOutputModel?> GetRandormRecipesAsync(int? number = 100, bool? includeNutrion = true, CancellationToken token = default);
}