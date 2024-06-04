using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Hony.Api.Models.Token;
using Hony.Application.Common.Models;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Hony.Api.Services.Authentication.Jwt;
/// <summary>
/// Inicializa una nueva instancia de la clase <see cref="JwtServicesDefault"/>.
/// Clase que implementa la interfaz <see cref="IJwtServices"/> y proporciona métodos para la creación de tokens JWT.
/// Utiliza la configuración de JWT proporcionada por <see cref="JwtSettings"/>.
/// </summary>
/// <param name="settings">La configuración de JWT.</param>
public sealed class JwtServicesDefault(IOptions<JwtSettings> settings) : IJwtServices
{
    /// <inheritdoc/>
    public async Task<TokenEntity> CreateTokenAsync(AccountCredentials credentials, string role, CancellationToken token)
    {
        Claim[] claims = [
            new (ClaimTypes.Role,role),
            new (JwtRegisteredClaimNames.Sub,credentials.Id.ToString()),
            new (JwtRegisteredClaimNames.Email,credentials.Email),
            new (JwtRegisteredClaimNames.UniqueName,credentials.UserName)
        ];
        var accessToken = GenerateToken(claims, TokenType.Normal);
        var refreshToken = GenerateToken([], TokenType.Refresh);
        Task.WaitAll([accessToken, refreshToken], token);
        return TokenEntity.Create(await accessToken, await refreshToken, credentials.Id, _settings.TokenExpiration);
    }
    private Task<string> GenerateToken(IEnumerable<Claim> claims, TokenType tokenType)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            signingCredentials: cred,
            claims: claims,
            expires: tokenType switch
            {
                TokenType.Normal => _settings.TokenExpiration,
                TokenType.Refresh => _settings.TokenExpiration.AddDays(1),
                _ => default
            }
        );
        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }
    private readonly JwtSettings _settings = settings.Value;
    /// <summary>
    /// Enumeración interna que representa el tipo de token.
    /// </summary>
    internal enum TokenType
    {
        /// <summary>
        /// Sin tipo de token.
        /// </summary>
        None,
        /// <summary>
        /// Token normal.
        /// </summary>
        Normal,
        /// <summary>
        /// Token de actualización.
        /// </summary>
        Refresh
    }
}