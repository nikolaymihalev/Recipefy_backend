using MediatR;
using Microsoft.Extensions.Configuration;
using Recipefy.Application.Contracts.Repositories;
using Recipefy.Application.Contracts.Services;
using Recipefy.Application.Utility.Helpers;
using Recipefy.Domain.Constants;
using Recipefy.Domain.Models.Entities;

namespace Recipefy.Application.Features.External.MealDB.Commands.AddNewIngredients;

public class SyncWithAllIngredientsCommand : IRequest<int>
{
}

public class SyncWithAllIngredientsCommandHandler : IRequestHandler<SyncWithAllIngredientsCommand, int>
{
    private readonly IMealDbService _mealDbService;
    private readonly IIngredientRepository _ingredientRepository;

    private readonly string _baseImageUrl;

    public SyncWithAllIngredientsCommandHandler(
        IMealDbService mealDbService,
        IIngredientRepository ingredientRepository,
        IConfiguration configuration)
    {
        _mealDbService = mealDbService;
        _ingredientRepository = ingredientRepository;
        
        _baseImageUrl = configuration["TheMealDB:BaseIngredientImageUrl"];
    }
    
    public async Task<int> Handle(SyncWithAllIngredientsCommand request, CancellationToken cancellationToken)
    {
        var externalIngredients = await _mealDbService.GetAllIngredientsAsync(cancellationToken);

        if (externalIngredients is null)
            return 0;

        var externalIds = externalIngredients.Meals
            .Where(x => x.IdIngredient is not null)
            .Select(x => x.IdIngredient)
            .ToArray();
        
        var dbIngredients = await _ingredientRepository.GetAllFilteredAsync(x=> externalIds.Contains(x.ExternalId.ToString()), cancellationToken);
        
        var dbIds = dbIngredients.Select(x => x.Id.ToString()).ToArray();
        
        var missingIdsInDb = GetMissingIngredientsInDbIds(externalIds!, dbIds);

        var missingIngredients = externalIngredients.Meals
            .Where(x => missingIdsInDb.Contains(x.IdIngredient))
            .Select(x => new Ingredient()
            {
                Name = string.IsNullOrEmpty(x.StrIngredient) ? string.Empty : x.StrIngredient,
                Description = x.StrDescription,
                ExternalId = string.IsNullOrEmpty(x.IdIngredient) ? null : int.Parse(x.IdIngredient),
                CreatedDate = DateTime.Now,
                ImageUrl = string.IsNullOrEmpty(x.StrIngredient)
                    ? null
                    : MealDbHelper.GetIngredientImageUrl(_baseImageUrl, x.StrIngredient, ModelConstants.FileExtensions.Png),
                Type = x.StrIngredient
            })
            .DistinctBy(x => x.ExternalId)
            .ToList();
        
        await _ingredientRepository.AddRangeAsync(missingIngredients, cancellationToken);
        
        return missingIngredients.Count();
    }
    
    private string[] GetMissingIngredientsInDbIds(string[] externalIds, string[] dbIds)
     => externalIds.Except(dbIds).ToArray();
}