using Microsoft.AspNetCore.Mvc;
using Recipefy.Application.Features.Common.Identity.Commands.Login;

namespace Recipefy.Web.Controllers;

public class IdentityController : ApiController
{
    [HttpPost]
    [Route(nameof(Login))]
    public async Task<ActionResult<object>> Login(
        [FromBody] LoginCommand command)
        => await Send(command);
}