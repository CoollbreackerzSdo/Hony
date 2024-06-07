using FluentValidation;

using Hony.Application.Services.Handlers.Validation;

namespace Hony.Application.Common.Validators;

/// <summary>
/// Validador para el comando de validación de cuenta.
/// </summary>
public class ValidateAccountValidator : AbstractValidator<ValidateAccountCommandHandler>
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ValidateAccountValidator"/>.
    /// </summary>
    public ValidateAccountValidator()
    {
        RuleFor(x => x.Password).NotEmpty().WithMessage("La contraseña no debe estar vacía.");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("El nombre de usuario no debe estar vacío.");
    }
}