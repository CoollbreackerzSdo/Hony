using FluentValidation;
using FluentValidation.Results;

using Hony.Application.Services.Handlers.Create;

namespace Hony.Api.Endpoints.Filters.Validation;
/// <summary>
/// Clase que implementa la interfaz <see cref="IEndpointFilter"/> y proporciona un filtro de validación para la creación de cuentas.
/// Inicializa una nueva instancia de la clase <see cref="ValidateCreateAccountFilter"/>.

/// <param name="validator">El validador utilizado para validar los comandos de creación de cuentas.</param>
/// </summary>
public class ValidateCreateAccountFilter(IValidator<CreateAccountCommandHandler> validator) : IEndpointFilter
{
    /// <inheritdoc/>
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        ValidationResult? validation = validator.Validate(context.GetArgument<CreateAccountCommandHandler>(0));
        return validation.IsValid ? await next(context) : Results.ValidationProblem(validation.ToDictionary());
    }
}