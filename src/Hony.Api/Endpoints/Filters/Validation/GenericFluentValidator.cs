using FluentValidation;
using FluentValidation.Results;

namespace Hony.Api.Endpoints.Filters.Validation;

/// <summary>
/// Filtro genérico para la validación de entidades.
/// </summary>
/// <typeparam name="T">El tipo de entidad a validar.</typeparam>
/// <param name="validator">El validador para la entidad de tipo <typeparamref name="T"/>.</param>
public class GenericFluentValidator<T>(IValidator<T> validator) : IEndpointFilter
{
    /// <summary>
    /// Invoca el filtro de validación de endpoint.
    /// </summary>
    /// <param name="context">El contexto de invocación del filtro del endpoint.</param>
    /// <param name="next">El delegado que representa el siguiente filtro o middleware en la cadena de ejecución.</param>
    /// <returns>
    /// Una tarea que representa la operación asincrónica. El resultado es <c>null</c> si la validación es exitosa;
    /// de lo contrario, una respuesta de problema de validación.
    /// </returns>
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        ValidationResult? validation = validator.Validate(context.GetArgument<T>(0));
        return validation.IsValid ? await next(context) : Results.ValidationProblem(validation.ToDictionary());
    }
}