using System.Security.Claims;

namespace Hony.Api.Services.Authentication.Tokens;

public interface IJwtService
{
    string GenerateToken(params Claim[] claims);
}