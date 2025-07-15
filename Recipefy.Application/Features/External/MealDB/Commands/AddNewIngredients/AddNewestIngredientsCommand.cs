using System.Net.Http.Json;
using MediatR;
using Microsoft.Extensions.Configuration;
using Recipefy.Application.Contracts.Services;
using Recipefy.Application.Features.External.MealDB.Common;

namespace Recipefy.Application.Features.External.MealDB.Commands.AddNewIngredients;

public class AddNewestIngredientsCommand : IRequest<int>
{
}

public class AddNewestIngredientsCommandHandler : IRequestHandler<AddNewestIngredientsCommand, int>
{
    private readonly IMealDbService _mealDbService;

    public AddNewestIngredientsCommandHandler(
        IMealDbService mealDbService)
    {
        _mealDbService = mealDbService;
    }
    
    public async Task<int> Handle(AddNewestIngredientsCommand request, CancellationToken cancellationToken)
    {
        var ingredients = await _mealDbService.GetAllIngredientsAsync(cancellationToken);
        
        return ingredients?.Meals.Length ?? 0;
    }
}