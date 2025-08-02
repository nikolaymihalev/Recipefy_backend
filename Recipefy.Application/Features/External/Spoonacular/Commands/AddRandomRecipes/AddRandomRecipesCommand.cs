using MediatR;
using Microsoft.Extensions.Configuration;
using Recipefy.Application.Contracts.Repositories;
using Recipefy.Application.Contracts.Requesters;
using Recipefy.Domain.Constants;
using Recipefy.Domain.Models.Entities;
using Recipefy.Domain.Models.Enums;
using CaloricBreakdown = Recipefy.Domain.Models.ValueObjects.CaloricBreakdown;
using Recipe = Recipefy.Domain.Models.Entities.Recipe;
using WeightPerServing = Recipefy.Domain.Models.ValueObjects.WeightPerServing;

namespace Recipefy.Application.Features.External.Spoonacular.Commands.AddRandomRecipes;

public class AddRandomRecipesCommand : IRequest<int>
{
    public int? Number { get; set; }
    public bool? IncludeNutrion { get; set; }
}

public class AddRandomRecipesCommandHandler : IRequestHandler<AddRandomRecipesCommand, int>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly ISpoonacularRequester _spoonacularRequester;

    private readonly string _baseImgUrl;
    
    private const int IngredientImageSize = 100;    
    
    public AddRandomRecipesCommandHandler(
        IRecipeRepository recipeRepository,
        ISpoonacularRequester spoonacularRequester,
        IConfiguration configuration)
    {
        _recipeRepository = recipeRepository;
        _spoonacularRequester = spoonacularRequester;

        _baseImgUrl = configuration["Spoonacular:BaseImageUrl"];
    }
    
    public async Task<int> Handle(AddRandomRecipesCommand request, CancellationToken cancellationToken)
    {
        var recipesResponse = await _spoonacularRequester.GetRandormRecipesAsync(request.Number, request.IncludeNutrion, cancellationToken);

        if (recipesResponse is null || recipesResponse.Recipes.Length is 0)
            return 0;
        
        var recipesExternalIdsDb = await _recipeRepository.GetAllRecipesExternalIds(cancellationToken);

        recipesResponse.Recipes = recipesResponse.Recipes
            .Where(x => recipesExternalIdsDb.Contains(x.Id) == false)
            .ToArray();

        var recipesToAdd = recipesResponse.Recipes
            .Select(x => new Recipe()
            {
                ExternalId = x.Id,
                ImageUrl = x.Image,
                Name = x.Title,
                PreparationMinutes = x.PreparationMinutes,
                IsVegeterian = x.Vegetarian,
                IsVegan = x.Vegan,
                IsCheap = x.Vegan,
                IsHealthy = x.VeryHealthy,
                IsDairyFree = x.DairyFree,
                IsGlutenFree = x.GlutenFree,
                IsPopular = x.VeryPopular,
                WeightWatherSmartPoints = x.WeightWatcherSmartPoints,
                HealthScore = x.HealthScore,
                Likes = x.AggregateLikes,
                PricePerServing = (decimal)x.PricePerServing,
                Description = x.Summary,
                Instructions = x.Instructions,
                DishTypes = string.Join(ModelConstants.Seperators.Semicolon, x.DishTypes),
                Diets = string.Join(ModelConstants.Seperators.Semicolon, x.Diets),
                WeightPerServing = new WeightPerServing()
                {
                    Amount = x.Nutrition.WeightPerServing.Amount,
                    Unit = x.Nutrition.WeightPerServing.Unit
                },
                CaloricBreakdown = new CaloricBreakdown()
                {
                    ProteinPercent = x.Nutrition.CaloricBreakdown.PercentProtein,
                    FatPercent = x.Nutrition.CaloricBreakdown.PercentFat,
                    CarbsPercent = x.Nutrition.CaloricBreakdown.PercentCarbs,
                },
                RecipeNutrients = x.Nutrition.Nutrients
                    .Select(n => new RecipeNutrient()
                    {
                        Name = n.Name,
                        Amount = n.Amount,
                        Unit = n.Unit,
                        PercentOfDailyNeeds = n.PercentOfDailyNeeds
                    }).ToList(),
                RecipeIngredients = x.ExtendedIngredients
                    .Select(i => new RecipeIngredient()
                    {
                        Amount = i.Amount,
                        Unit = i.Unit,
                        Ingredient = new Ingredient()
                        {
                            ExternalId = i.Id,
                            ImageUrl =
                                $"{_baseImgUrl}/ingredients_{IngredientImageSize}x{IngredientImageSize}/{i.Image}",
                            Name = i.Original,
                            Consistency = Enum.TryParse<IngredientConsistency>(i.Consistency, true, out var result)
                                ? result
                                : IngredientConsistency.NotSet
                        }
                    }).ToList()
            })
            .ToList();

        await _recipeRepository.AddRangeAsync(recipesToAdd, cancellationToken);

        return recipesToAdd.Count;
    }
}