using Recipefy.Application.Features.External.MealDB.Common;

namespace Recipefy.Application.Features.External.MealDB.Commands.AddNewIngredients;

public class GetIngredientsOutputModel
{
    public IngredientDTOModel[] Meals { get; set; }
}