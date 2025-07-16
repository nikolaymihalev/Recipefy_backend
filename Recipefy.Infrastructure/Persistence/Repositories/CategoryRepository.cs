using Recipefy.Application.Contracts.Repositories;
using Recipefy.Domain.Models.Entities;

namespace Recipefy.Infrastructure.Persistence.Repositories;

public class CategoryRepository: DataRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}