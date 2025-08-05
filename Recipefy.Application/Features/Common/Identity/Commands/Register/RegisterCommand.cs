using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Recipefy.Application.Features.Common.Identity.Commands.Register;

public class RegisterCommand : IRequest<object>
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, object>
{
    private readonly UserManager<IdentityUser> _userManager;

    public RegisterCommandHandler(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<object> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new IdentityUser{UserName = request.Username, Email = request.Email};
        
        var result = await _userManager.CreateAsync(user, request.Password);
        
        if(result.Succeeded is false)
            return new InvalidOperationException(result.Errors.ToString());

        if(request.Password != request.ConfirmPassword)
            return new InvalidOperationException("Passwords don't match");
        
        return new
        {
            Message = "User successfully created"
        };
    }
}

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("Email is required");
        
        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage("Password is required");
        
        RuleFor(x => x.ConfirmPassword)
            .NotNull()
            .NotEmpty()
            .WithMessage("Confirm Password is required");
        
        RuleFor(x => x.Username)
            .NotNull()
            .NotEmpty()
            .WithMessage("Username is required");
    }
}