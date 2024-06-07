
using System.Security.Claims;

using Hony.Api.Endpoints.Filters.Validation;
using Hony.Api.Services.Authentication.Providers;
using Hony.Application.Common.Models;
using Hony.Application.Services.Handlers;
using Hony.Application.Services.Handlers.Create;

namespace Hony.Api.Endpoints.Managers;

public class BlogEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder builder)
    {
        var api = builder.MapGroup("blogs").RequireAuthorization([PoliciesProviderDefault.USER_VALORICE,]);

        api.MapPost("", async (CreateBlogCommandHandler command, ClaimsPrincipal userClaims, IHandlerAsync<(Guid, CreateBlogCommandHandler), BlogView> handler, CancellationToken token) =>
        {
            var handleResult = await handler.HandleAsync((new(userClaims.FindFirstValue(ClaimTypes.NameIdentifier)!), command), token);
            return handleResult.IsSuccess ? Results.Ok(handleResult.Value) : Results.NotFound();
        }).AddEndpointFilter<GenericValidator<CreateBlogCommandHandler>>().Accepts<CreateBlogCommandHandler>("application/json")
        .Produces<BlogView>(StatusCodes.Status200OK)
        .WithTags(["Blogs"])
        .WithOpenApi();
    }
}