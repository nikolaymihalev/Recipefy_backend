using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recipefy.Domain.Models.Entities;
using Recipefy.Infrastructure.Persistence.Configurations;

namespace Recipefy.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public DbSet<RecipeNutrient> RecipeNutrients { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new RecipeNutrientConfiguration());
        builder.ApplyConfiguration(new RecipeIngredientConfiguration());
        
        base.OnModelCreating(builder);
    }
}