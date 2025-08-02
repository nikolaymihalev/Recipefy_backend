using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipefy.Application.Features.External.Spoonacular.Commands.AddRandomRecipes;

namespace Recipefy.Web.Controllers;

public class SpoonacularController : ApiController
{
    [HttpPost]
    [Route(nameof(AddRandomRecipes))]
    public async Task<ActionResult<int>> AddRandomRecipes(
        [FromQuery] AddRandomRecipesCommand command)  
        => await Send(command);
}