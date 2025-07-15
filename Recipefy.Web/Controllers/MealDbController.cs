using Microsoft.AspNetCore.Mvc;
using Recipefy.Application.Features.External.MealDB.Commands.AddNewIngredients;

namespace Recipefy.Web.Controllers;

public class MealDbController : ApiController
{
    [HttpPost]
    [Route(nameof(AddNewIngredients))]
    public async Task<ActionResult<int>> AddNewIngredients(
        [FromQuery] AddNewIngredientsCommand command)
        => await Send(command);
}