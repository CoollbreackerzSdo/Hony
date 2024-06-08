using Hony.Api.Services.Authentication.Providers;

namespace Hony.Api.Endpoints.Managers;

public class CategoryEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder builder)
    {
        var api = builder.MapGroup("categories").RequireAuthorization([PoliciesProviderDefault.MANAGES_VALORICE]);
    }   
}