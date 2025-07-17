using Recipefy.Domain.Common;

namespace Recipefy.Domain.Models.ValueObjects;

public class WeightPerServing : ValueObject
{
    public double Amount { get; set; }
    public string? Unit { get; set; }
}