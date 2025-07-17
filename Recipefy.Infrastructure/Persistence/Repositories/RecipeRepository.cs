using Recipefy.Application.Contracts.Repositories;
using Recipefy.Domain.Models.Entities;

namespace Recipefy.Infrastructure.Persistence.Repositories;

public class RecipeRepository : DataRepository<Recipe>, IRecipeRepository
{
    public RecipeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}