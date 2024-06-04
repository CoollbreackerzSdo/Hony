using Ardalis.Result;

namespace Hony.Application.Services.Handlers;

/// <summary>
/// Interfaz genérica para un manejador de solicitudes asincrónicas.
/// </summary>
/// <typeparam name="TRequest">El tipo de solicitud manejada por el manejador.</typeparam>
public interface IHandlerAsync<TRequest>
{
    /// <summary>
    /// Maneja de forma asincrónica la solicitud especificada.
    /// </summary>
    /// <param name="request">La solicitud a manejar.</param>
    /// <param name="token">Token de cancelación opcional para la operación asincrónica.</param>
    /// <returns>Una tarea que representa la operación asincrónica y contiene un resultado de la operación.</returns>
    public Task<Result> HandleAsync(TRequest request, CancellationToken token = default);
}

/// <summary>
/// Interfaz genérica para un manejador de solicitudes asincrónicas con respuesta.
/// </summary>
/// <typeparam name="TRequest">El tipo de solicitud manejada por el manejador.</typeparam>
/// <typeparam name="TResponse">El tipo de respuesta producida por el manejador.</typeparam>
public interface IHandlerAsync<TRequest, TResponse>
{
    /// <summary>
    /// Maneja de forma asincrónica la solicitud especificada.
    /// </summary>
    /// <param name="request">La solicitud a manejar.</param>
    /// <param name="token">Token de cancelación opcional para la operación asincrónica.</param>
    /// <returns>Una tarea que representa la operación asincrónica y contiene un resultado de la operación que incluye la respuesta producida por el manejador.</returns>
    public Task<Result<TResponse>> HandleAsync(TRequest request, CancellationToken token = default);
}