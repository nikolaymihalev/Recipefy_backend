using System.Text.Json.Serialization;

namespace Recipefy.Application.Features.External.Spoonacular.Models;

public class SpoonacularOutputModels
{
}

public class Recipe
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("image")] public string Image { get; set; }
    [JsonPropertyName("imageType")] public string ImageType { get; set; }
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("readyInMinutes")] public int ReadyInMinutes { get; set; }
    [JsonPropertyName("servings")] public int Servings { get; set; }
    [JsonPropertyName("sourceUrl")] public string SourceUrl { get; set; }
    [JsonPropertyName("vegetarian")] public bool Vegetarian { get; set; }
    [JsonPropertyName("vegan")] public bool Vegan { get; set; }
    [JsonPropertyName("glutenFree")] public bool GlutenFree { get; set; }
    [JsonPropertyName("dairyFree")] public bool DairyFree { get; set; }
    [JsonPropertyName("veryHealthy")] public bool VeryHealthy { get; set; }
    [JsonPropertyName("cheap")] public bool Cheap { get; set; }
    [JsonPropertyName("veryPopular")] public bool VeryPopular { get; set; }
    [JsonPropertyName("sustainable")] public bool Sustainable { get; set; }
    [JsonPropertyName("lowFodmap")] public bool LowFodmap { get; set; }

    [JsonPropertyName("weightWatcherSmartPoints")]
    public int WeightWatcherSmartPoints { get; set; }

    [JsonPropertyName("gaps")] public string Gaps { get; set; }

    [JsonPropertyName("preparationMinutes")]
    public int? PreparationMinutes { get; set; }

    [JsonPropertyName("cookingMinutes")] public int? CookingMinutes { get; set; }
    [JsonPropertyName("aggregateLikes")] public int AggregateLikes { get; set; }
    [JsonPropertyName("healthScore")] public int HealthScore { get; set; }
    [JsonPropertyName("creditsText")] public string CreditsText { get; set; }
    [JsonPropertyName("license")] public string License { get; set; }
    [JsonPropertyName("sourceName")] public string SourceName { get; set; }
    [JsonPropertyName("pricePerServing")] public double PricePerServing { get; set; }

    [JsonPropertyName("extendedIngredients")]
    public List<ExtendedIngredient> ExtendedIngredients { get; set; }

    [JsonPropertyName("nutrition")] public Nutrition Nutrition { get; set; }
    [JsonPropertyName("summary")] public string Summary { get; set; }
    [JsonPropertyName("cuisines")] public List<string> Cuisines { get; set; }
    [JsonPropertyName("dishTypes")] public List<string> DishTypes { get; set; }
    [JsonPropertyName("diets")] public List<string> Diets { get; set; }
    [JsonPropertyName("occasions")] public List<string> Occasions { get; set; }
    [JsonPropertyName("instructions")] public string Instructions { get; set; }

    [JsonPropertyName("analyzedInstructions")]
    public List<AnalyzedInstruction> AnalyzedInstructions { get; set; }

    [JsonPropertyName("originalId")] public object OriginalId { get; set; }
    [JsonPropertyName("spoonacularScore")] public double SpoonacularScore { get; set; }

    [JsonPropertyName("spoonacularSourceUrl")]
    public string SpoonacularSourceUrl { get; set; }
}

public class ExtendedIngredient
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("aisle")] public string Aisle { get; set; }
    [JsonPropertyName("image")] public string Image { get; set; }
    [JsonPropertyName("consistency")] public string Consistency { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("nameClean")] public string NameClean { get; set; }
    [JsonPropertyName("original")] public string Original { get; set; }
    [JsonPropertyName("originalName")] public string OriginalName { get; set; }
    [JsonPropertyName("amount")] public double Amount { get; set; }
    [JsonPropertyName("unit")] public string Unit { get; set; }
    [JsonPropertyName("meta")] public List<string> Meta { get; set; }
    [JsonPropertyName("measures")] public Measures Measures { get; set; }
}

public class Measures
{
    [JsonPropertyName("us")] public MeasureDetail Us { get; set; }
    [JsonPropertyName("metric")] public MeasureDetail Metric { get; set; }
}

public class MeasureDetail
{
    [JsonPropertyName("amount")] public double Amount { get; set; }
    [JsonPropertyName("unitShort")] public string UnitShort { get; set; }
    [JsonPropertyName("unitLong")] public string UnitLong { get; set; }
}

public class Nutrition
{
    [JsonPropertyName("nutrients")] public List<Nutrient> Nutrients { get; set; }
    [JsonPropertyName("properties")] public List<Property> Properties { get; set; }
    [JsonPropertyName("flavonoids")] public List<Flavonoid> Flavonoids { get; set; }
    [JsonPropertyName("ingredients")] public List<IngredientNutrition> Ingredients { get; set; }
    [JsonPropertyName("caloricBreakdown")] public CaloricBreakdown CaloricBreakdown { get; set; }
    [JsonPropertyName("weightPerServing")] public WeightPerServing WeightPerServing { get; set; }
}

public class Nutrient
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("amount")] public double Amount { get; set; }
    [JsonPropertyName("unit")] public string Unit { get; set; }

    [JsonPropertyName("percentOfDailyNeeds")]
    public double? PercentOfDailyNeeds { get; set; }
}

public class Property
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("amount")] public double Amount { get; set; }
    [JsonPropertyName("unit")] public string Unit { get; set; }
}

public class Flavonoid
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("amount")] public double Amount { get; set; }
    [JsonPropertyName("unit")] public string Unit { get; set; }
}

public class IngredientNutrition
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("amount")] public double Amount { get; set; }
    [JsonPropertyName("unit")] public string Unit { get; set; }
    [JsonPropertyName("nutrients")] public List<Nutrient> Nutrients { get; set; }
}

public class CaloricBreakdown
{
    [JsonPropertyName("percentProtein")] public double PercentProtein { get; set; }
    [JsonPropertyName("percentFat")] public double PercentFat { get; set; }
    [JsonPropertyName("percentCarbs")] public double PercentCarbs { get; set; }
}

public class WeightPerServing
{
    [JsonPropertyName("amount")] public int Amount { get; set; }
    [JsonPropertyName("unit")] public string Unit { get; set; }
}

public class AnalyzedInstruction
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("steps")] public List<Step> Steps { get; set; }
}

public class Step
{
    [JsonPropertyName("number")] public int Number { get; set; }
    [JsonPropertyName("step")] public string Instruction { get; set; }
    [JsonPropertyName("ingredients")] public List<ShortIngredient> Ingredients { get; set; }
    [JsonPropertyName("equipment")] public List<Equipment> Equipment { get; set; }
}

public class ShortIngredient
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("localizedName")] public string LocalizedName { get; set; }
    [JsonPropertyName("image")] public string Image { get; set; }
}

public class Equipment
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("localizedName")] public string LocalizedName { get; set; }
    [JsonPropertyName("image")] public string Image { get; set; }
}

public class GetRandorRecipesOutputModel 
{
    public Recipe[] Recipes { get; set; }
}