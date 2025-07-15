using System.Net.Http.Json;
using MediatR;
using Microsoft.Extensions.Configuration;
using Recipefy.Application.Features.External.MealDB.Common;

namespace Recipefy.Application.Features.External.MealDB.Commands.AddNewIngredients;

public class AddNewestIngredientsCommand : IRequest<int>
{
}

public class AddNewestIngredientsCommandHandler : IRequestHandler<AddNewestIngredientsCommand, int>
{
    private readonly string _baseUrl;
    
    public AddNewestIngredientsCommandHandler(
        IConfiguration configuration)
    {
        _baseUrl = configuration.GetSection("TheMealDB:BaseUrl").Value!;
    }
    
    public async Task<int> Handle(AddNewestIngredientsCommand request, CancellationToken cancellationToken)
    {
        var query = "list.php?i=list";
        
        using var client = new HttpClient();
        client.BaseAddress = new Uri(_baseUrl);
        
        var ingredients = await client.GetFromJsonAsync<GetIngredientsOutputModel>(query, cancellationToken);
        
        return ingredients.Meals.Length;
    }
}