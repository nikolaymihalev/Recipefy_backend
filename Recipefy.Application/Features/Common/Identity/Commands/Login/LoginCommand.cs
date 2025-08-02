using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Recipefy.Application.Utility.Common;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Recipefy.Application.Features.Common.Identity.Commands.Login;

public class LoginCommand : IRequest<object>
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, object>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtSettings _jwtSettings;
    
    private const string JwtKey = "Jwt";
    
    public LoginCommandHandler(
        IConfiguration configuration,
        UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
        configuration.GetSection(JwtKey).Bind(_jwtSettings);
    }
    
    public async Task<object> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        
        if(user is null) 
            throw new ApplicationException($"User with email {request.Email} does not exist");
        
        if(await _userManager.CheckPasswordAsync(user, request.Password) == false)
            return new UnauthorizedAccessException("Invalid credentials");
        
        var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)), SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, request.Email),
            new Claim("role", "User"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes),
            signingCredentials: creds
        );

        return new
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        };
    }
}

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("Email is required");
        
        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage("Password is required");
    }
}