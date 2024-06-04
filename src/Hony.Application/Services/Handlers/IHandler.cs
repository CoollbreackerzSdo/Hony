using Ardalis.Result;

namespace Hony.Application.Services.Handlers;

/// <summary>
/// Interfaz genérica para un manejador de solicitudes.
/// </summary>
/// <typeparam name="TRequest">El tipo de solicitud manejada por el manejador.</typeparam>
public interface IHandler<TRequest>
{
    /// <summary>
    /// Maneja la solicitud especificada.
    /// </summary>
    /// <param name="request">La solicitud a manejar.</param>
    /// <returns>Un resultado de la operación.</returns>
    public Result Handle(TRequest request);
}

/// <summary>
/// Interfaz genérica para un manejador de solicitudes con respuesta.
/// </summary>
/// <typeparam name="TRequest">El tipo de solicitud manejada por el manejador.</typeparam>
/// <typeparam name="TResponse">El tipo de respuesta producida por el manejador.</typeparam>
public interface IHandler<TRequest, TResponse>
{
    /// <summary>
    /// Maneja la solicitud especificada.
    /// </summary>
    /// <param name="request">La solicitud a manejar.</param>
    /// <returns>Un resultado de la operación que contiene la respuesta producida por el manejador.</returns>
    public Result<TResponse> Handle(TRequest request);
}