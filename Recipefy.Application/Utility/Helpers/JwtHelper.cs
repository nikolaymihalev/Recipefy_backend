using System.IdentityModel.Tokens.Jwt;

namespace Recipefy.Application.Utility.Helpers;

public class JwtHelper
{
    public static bool IsJwtTokenExpired(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        if (!tokenHandler.CanReadToken(token))
            throw new ArgumentException("Invalid JWT token format.");

        var jwtToken = tokenHandler.ReadJwtToken(token);

        var exp = jwtToken.ValidTo;

        return exp < DateTime.UtcNow;
    }
}