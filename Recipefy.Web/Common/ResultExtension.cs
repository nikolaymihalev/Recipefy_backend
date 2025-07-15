using Microsoft.AspNetCore.Mvc;

namespace Recipefy.Web.Common;

public static class ResultExtension
{
    public static async Task<ActionResult<TData>> ToActionResult<TData>(this Task<TData> task)
    {
        var result = await task;
        
        if(result is null)
            return new NotFoundResult();

        return result;
    }

    public static async Task<ActionResult> ToActionResult(this Task<Result> task)
    {
        var result = await task;
        
        if(!result.Succeeded)
            return new BadRequestObjectResult(result.Errors as object);
        
        return new OkResult();
    }

    public static async Task<ActionResult<TData>> ToActionResult<TData>(this Task<Result<TData>> task)
    {
        var result = await task;
        
        if(!result.Succeeded)
            return new BadRequestObjectResult(result.Errors as object);

        return result.Data;
    }
}