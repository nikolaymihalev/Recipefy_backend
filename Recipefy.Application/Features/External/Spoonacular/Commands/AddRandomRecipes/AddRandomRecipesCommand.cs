using MediatR;

namespace Recipefy.Application.Features.External.Spoonacular.Commands.AddRandomRecipes;

public class AddRandomRecipesCommand : IRequest<int>
{
}

public class AddRandomRecipesCommandHandler : IRequestHandler<AddRandomRecipesCommand, int>
{
    public Task<int> Handle(AddRandomRecipesCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}