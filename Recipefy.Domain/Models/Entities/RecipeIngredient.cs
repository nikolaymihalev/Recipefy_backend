using System.ComponentModel.DataAnnotations.Schema;

namespace Recipefy.Domain.Models.Entities;

public class RecipeIngredient
{
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public double Amount { get; set; }
    public string? Unit { get; set; }

    [ForeignKey(nameof(RecipeId))] public Recipe Recipe { get; set; }
    [ForeignKey(nameof(IngredientId))] public Ingredient Ingredient { get; set; }
}