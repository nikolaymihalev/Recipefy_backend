using Recipefy.Application.Contracts.Repositories;
using Recipefy.Domain.Models.Entities;

namespace Recipefy.Infrastructure.Persistence.Repositories;

public class IngredientRepository : DataRepository<Ingredient>, IIngredientRepository
{
    public IngredientRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}