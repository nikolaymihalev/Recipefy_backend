using MediatR;
using Recipefy.Application.Contracts.Repositories;
using Recipefy.Application.Contracts.Services;
using Recipefy.Domain.Models.Entities;

namespace Recipefy.Application.Features.External.MealDB.Commands.SyncWithAllCategories;

public class SyncWithAllCategoriesCommand : IRequest<int>
{
}

public class SyncWithAllCategoriesCommandHandler : IRequestHandler<SyncWithAllCategoriesCommand, int>
{
    private readonly IMealDbService _mealDbService;
    private readonly ICategoryRepository _categoryRepository;

    public SyncWithAllCategoriesCommandHandler(
        IMealDbService mealDbService,
        ICategoryRepository categoryRepository)
    {
        _mealDbService = mealDbService;
        _categoryRepository = categoryRepository;
    }
    
    public async Task<int> Handle(SyncWithAllCategoriesCommand request, CancellationToken cancellationToken)
    {
        var externalCategories = await _mealDbService.GetAllCategoriesAsync(cancellationToken);

        if (externalCategories is null)
            return 0;

        var externalCategoriesNames = externalCategories.Meals
            .Select(x => x.StrCategory)
            .ToArray();

        var dbCategories = await _categoryRepository.GetAllFilteredAsync(x => externalCategoriesNames.Contains(x.Name), cancellationToken);
        
        var dbCategoriesNames = dbCategories.Select(x => x.Name).ToArray();
        
        var missingNames = GetMissingCategoriesInDb(externalCategoriesNames, dbCategoriesNames);

        var missingCategories = externalCategories.Meals
            .Where(x => missingNames.Contains(x.StrCategory))
            .Select(x => new Category()
            {
                Name = x.StrCategory
            })
            .ToList();
        
        await _categoryRepository.AddRangeAsync(missingCategories, cancellationToken);

        return missingCategories.Count();
    }
    
    private string[] GetMissingCategoriesInDb(string[] external, string[] db)
        => external.Except(db).ToArray();
}