using FluentValidation;

using Hony.Application.Services.Handlers.Create;

namespace Hony.Application.Common.Validators;

public class CreateAccountValidator : AbstractValidator<CreateAccountCommandHandler>
{
    public CreateAccountValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password)
            .MinimumLength(8).Must(x => x.Any(char.IsNumber));
    }
}