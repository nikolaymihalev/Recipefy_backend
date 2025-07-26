using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipefy.Domain.Models.Entities;

namespace Recipefy.Infrastructure.Persistence.Configurations;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.HasKey(r => new { r.RecipeId, r.IngredientId });

        builder.HasOne(x => x.Recipe).WithMany(x => x.RecipeIngredients).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Ingredient).WithMany(x => x.RecipeIngredients).OnDelete(DeleteBehavior.Cascade);
    }
}