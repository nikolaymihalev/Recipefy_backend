using Recipefy.Domain.Common;
using Recipefy.Domain.Models.ValueObjects;

namespace Recipefy.Domain.Models.Entities;

public class Recipe : Entity<int>, IAggregateRoot
{
    public int? ExternalId { get; set; }
    public string? ImageUrl { get; set; }
    public string Name { get; set; }
    public int? PreparationMinutes { get; set; }
    public bool IsVegeterian { get; set; } = false;
    public bool IsVegan { get; set; } = false;
    public bool IsGlutenFree { get; set; } = false;
    public bool IsDairyFree { get; set; } = false;
    public bool IsHealthy { get; set; } = false;
    public bool IsCheap { get; set; }
    public bool IsPopular { get; set; } = false;
    public int? WeightWatherSmartPoints { get; set; }
    public int? HealthScore { get; set; }
    public int Likes { get; set; }
    public decimal PricePerServing { get; set; }
    public WeightPerServing WeightPerServing { get; set; }
    public CaloricBreakdown? CaloricBreakdown { get; set; }
    public string? Description { get; set; }
    public string Instructions { get; set; }
    public string? DishTypes { get; set; }
    public string? Diets { get; set; }
    
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    public ICollection<RecipeNutrient> RecipeNutrients { get; set; } = new List<RecipeNutrient>();
}