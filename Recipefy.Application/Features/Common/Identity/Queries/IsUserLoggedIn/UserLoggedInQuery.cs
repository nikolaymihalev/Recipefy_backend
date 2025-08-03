using FluentValidation;
using MediatR;
using Recipefy.Application.Utility.Helpers;

namespace Recipefy.Application.Features.Common.Identity.Queries.IsUserLoggedIn;

public class UserLoggedInQuery : IRequest<bool>
{
    public string Token { get; set; }    
}

public class UserLoggedInQueryHandler : IRequestHandler<UserLoggedInQuery, bool>
{
    public async Task<bool> Handle(UserLoggedInQuery request, CancellationToken cancellationToken)
    {
        try
        {
            bool isExpired = JwtHelper.IsJwtTokenExpired(request.Token);

            if (isExpired)
                return false;
        
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            return false;
        }
    }
}

public class UserLoggedInQueryValidator : AbstractValidator<UserLoggedInQuery>
{
    public UserLoggedInQueryValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty()
            .NotEmpty()
            .WithMessage("Token is required");
    }   
}