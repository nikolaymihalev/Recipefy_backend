using Microsoft.EntityFrameworkCore;
using Recipefy.Application.Contracts.Repositories;
using Recipefy.Domain.Models.Entities;

namespace Recipefy.Infrastructure.Persistence.Repositories;

public class RecipeRepository : DataRepository<Recipe>, IRecipeRepository
{
    public RecipeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<int[]> GetAllRecipesExternalIds(CancellationToken cancellationToken = default)
    {
        return await DbSet()
            .Where(x => x.ExternalId != null & x.ExternalId.HasValue)
            .Select(x => x.ExternalId!.Value)
            .ToArrayAsync(cancellationToken);
    }
}