using Microsoft.AspNetCore.Mvc;
using Recipefy.Application.Features.External.MealDB.Commands.AddNewIngredients;

namespace Recipefy.Web.Controllers;

public class AdminController : ApiController
{
    [HttpPost]
    [Route(nameof(AddNewestIngredients))]
    public async Task<ActionResult<int>> AddNewestIngredients(
        [FromQuery] AddNewestIngredientsCommand command)
        => await Send(command);
}