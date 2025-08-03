using Microsoft.AspNetCore.Mvc;
using Recipefy.Application.Features.Common.Identity.Commands.Login;
using Recipefy.Application.Features.Common.Identity.Commands.Register;
using Recipefy.Application.Features.Common.Identity.Queries.IsUserLoggedIn;

namespace Recipefy.Web.Controllers;

public class IdentityController : ApiController
{
    [HttpPost]
    [Route(nameof(Login))]
    public async Task<ActionResult<object>> Login(
        [FromBody] LoginCommand command)
        => await Send(command);

    [HttpPost]
    [Route(nameof(Register))]
    public async Task<ActionResult<object>> Register(
        RegisterCommand command)
        => await Send(command);
    
    [HttpGet]
    [Route(nameof(IsUserLoggedIn))]
    public async Task<ActionResult<bool>> IsUserLoggedIn(
        [FromQuery] UserLoggedInQuery query)
        => await Send(query);
}