using MediatR;
using Recipefy.Application.Contracts.Services;

namespace Recipefy.Application.Features.External.Spoonacular.Commands.AddRandomRecipes;

public class AddRandomRecipesCommand : IRequest<int>
{
    public int? Number { get; set; }
    public bool? IncludeNutrion { get; set; }
}

public class AddRandomRecipesCommandHandler : IRequestHandler<AddRandomRecipesCommand, int>
{
    private readonly ISpoonacularService _spoonacularService;

    public AddRandomRecipesCommandHandler(
        ISpoonacularService spoonacularService)
    {
        _spoonacularService = spoonacularService;
    }
    
    public async Task<int> Handle(AddRandomRecipesCommand request, CancellationToken cancellationToken)
    {
        var recipesResponse = await _spoonacularService.GetRandormRecipesAsync(request.Number, request.IncludeNutrion, cancellationToken);
    }
}