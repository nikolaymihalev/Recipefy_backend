using Recipefy.Application.Contracts.Common;
using Recipefy.Application.Features.External.MealDB.Commands.AddNewIngredients;

namespace Recipefy.Application.Contracts.Services;

public interface IMealDbService : IScopedService
{
    Task<GetIngredientsOutputModel?> GetAllIngredientsAsync(CancellationToken cancellationToken = default);
}