using Recipefy.Application.Contracts.Common;
using Recipefy.Application.Features.External.MealDB.Commands.SyncWithAllCategories;
using Recipefy.Application.Features.External.MealDB.Commands.SyncWithAllIngredients;

namespace Recipefy.Application.Contracts.Services;

public interface IMealDbService : IScopedService
{
    Task<GetIngredientsOutputModel?> GetAllIngredientsAsync(CancellationToken cancellationToken = default);
    Task<GetCategoryOutputModel?> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
}