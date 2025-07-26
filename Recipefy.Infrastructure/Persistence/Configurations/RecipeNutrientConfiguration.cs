using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipefy.Domain.Models.Entities;

namespace Recipefy.Infrastructure.Persistence.Configurations;

public class RecipeNutrientConfiguration : IEntityTypeConfiguration<RecipeNutrient>
{
    public void Configure(EntityTypeBuilder<RecipeNutrient> builder)
    {
        builder.HasOne(x => x.Recipe).WithMany(x => x.RecipeNutrients).OnDelete(DeleteBehavior.Cascade);
    }
}