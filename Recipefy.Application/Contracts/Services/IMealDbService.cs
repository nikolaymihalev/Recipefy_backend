using Recipefy.Application.Features.External.MealDB.Commands.AddNewIngredients;

namespace Recipefy.Application.Contracts.Services;

public interface IMealDbService
{
    Task<GetIngredientsOutputModel?> GetAllIngredientsAsync(CancellationToken cancellationToken = default);
}