using Ardalis.Result;

namespace Hony.Application.Services.Handlers;

public interface IHandlerAsync<TRequest>
{
    public Task<Result> HandleAsync(TRequest request, CancellationToken token = default);
}
public interface IHandlerAsync<TRequest, TResponse>
{
    public Task<Result<TResponse>> HandleAsync(TRequest request, CancellationToken token = default);
}