using Ardalis.Result;

namespace Hony.Application.Services.Handlers;

public interface IHandler<TRequest>
{
    public Result Handle(TRequest request);
}
public interface IHandler<TRequest, TResponse>
{
    public Result<TResponse> Handle(TRequest request);
}