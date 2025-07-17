using Recipefy.Domain.Common;
using Recipefy.Domain.Models.Enums;

namespace Recipefy.Domain.Models.Entities;

public class Ingredient : Entity<int>, IAggregateRoot
{
    public int? ExternalId { get; set; }
    public string ImageUrl { get; set; }
    public string Name { get; set; }
    public IngredientConsistency Consistency { get; set; }

    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}