namespace Recipefy.Application.Features.External.MealDB.Commands.SyncWithAllIngredients;

public class GetIngredientsOutputModel
{
    public IngredientDTOModel[] Meals { get; set; }
}