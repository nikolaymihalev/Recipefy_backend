using Microsoft.AspNetCore.Mvc;
using Recipefy.Application.Features.External.MealDB.Commands.SyncWithAllCategories;
using Recipefy.Application.Features.External.MealDB.Commands.SyncWithAllIngredients;

namespace Recipefy.Web.Controllers;

public class AdminController : ApiController
{
    [HttpPost]
    [Route(nameof(SyncWithAllIngredients))]
    public async Task<ActionResult<int>> SyncWithAllIngredients(
        [FromQuery] SyncWithAllIngredientsCommand command)
        => await Send(command);
    
    [HttpPost]
    [Route(nameof(SyncWithAllCategories))]
    public async Task<ActionResult<int>> SyncWithAllCategories(
        SyncWithAllCategoriesCommand command)
        => await Send(command);
}