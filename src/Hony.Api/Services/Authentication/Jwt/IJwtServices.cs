using Hony.Api.Models.Token;
using Hony.Application.Common.Models;

namespace Hony.Api.Services.Authentication.Jwt;

public interface IJwtServices
{
    Task<TokenEntity> CreateTokenAsync(AccountCredentials credentials, string role, CancellationToken token);
}