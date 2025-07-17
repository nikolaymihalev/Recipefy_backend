using System.ComponentModel.DataAnnotations.Schema;
using Recipefy.Domain.Common;

namespace Recipefy.Domain.Models.Entities;

public class RecipeNutrient : Entity<int>, IAggregateRoot
{
    public string Name { get; set; }
    public double Amount { get; set; }
    public string? Unit { get; set; }
    public double? PercentOfDailyNeeds { get; set; }
    public int RecipeId { get; set; }
    
    [ForeignKey(nameof(RecipeId))] public Recipe Recipe { get; set; }
}