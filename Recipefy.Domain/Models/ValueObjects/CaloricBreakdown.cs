using Recipefy.Domain.Common;

namespace Recipefy.Domain.Models.ValueObjects;

public class CaloricBreakdown : ValueObject
{
    public double ProteinPercent { get; set; }
    public double FatPercent { get; set; }
    public double CarbsPercent { get; set; }
}