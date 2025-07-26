using Recipefy.Application.Contracts.Common;
using Recipefy.Domain.Models.Entities;

namespace Recipefy.Application.Contracts.Repositories;

public interface IRecipeRepository : IRepository<Recipe>
{
    Task<int[]> GetAllRecipesExternalIds(CancellationToken cancellationToken = default);
}