using MediatR;

namespace Recipefy.Application.Features.External.MealDB.Commands.AddNewIngredients;

public class AddNewIngredientsCommand : IRequest<int>
{
}

public class AddNewIngredientsCommandHandler : IRequestHandler<AddNewIngredientsCommand, int>
{
    public Task<int> Handle(AddNewIngredientsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}