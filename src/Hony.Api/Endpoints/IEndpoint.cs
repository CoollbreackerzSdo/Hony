namespace Hony.Api.Endpoints;

public interface IEndpoint
{
    void Map(IEndpointRouteBuilder builder);
}