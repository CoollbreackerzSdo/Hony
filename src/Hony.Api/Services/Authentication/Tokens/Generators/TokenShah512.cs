using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.IdentityModel.Tokens;

namespace Hony.Api.Services.Authentication.Tokens.Generators;

public sealed class TokenShah512(JwtSettings settings) : IJwtService
{
    public string GenerateToken(params Claim[] claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: cred,
            expires: settings.ExpirationTick
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}