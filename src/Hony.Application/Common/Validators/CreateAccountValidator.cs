using FluentValidation;

using Hony.Application.Services.Handlers.Create;

namespace Hony.Application.Common.Validators;

/// <summary>
/// Clase que proporciona validación para el comando de creación de cuenta <see cref="CreateAccountCommandHandler"/>.
/// </summary>
public class CreateAccountValidator : AbstractValidator<CreateAccountCommandHandler>
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="CreateAccountValidator"/>.
    /// Define reglas de validación para los campos del comando de creación de cuenta.
    /// </summary>
    public CreateAccountValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password)
            .MinimumLength(8).Must(x => x.Any(char.IsNumber));
    }
}