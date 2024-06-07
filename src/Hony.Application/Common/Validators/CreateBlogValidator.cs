using FluentValidation;

using Hony.Application.Services.Handlers.Create;

namespace Hony.Application.Common.Validators;

/// <summary>
/// Validador para el comando de creación de blogs.
/// </summary>
public class CreateBlogValidator : AbstractValidator<CreateBlogCommandHandler>
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="CreateBlogValidator"/>.
    /// </summary>
    public CreateBlogValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(5).MaximumLength(1_000);
        RuleFor(x => x.Content).NotEmpty().MaximumLength(2_000);
    }
}