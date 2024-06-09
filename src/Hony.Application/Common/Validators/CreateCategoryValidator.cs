using FluentValidation;

using Hony.Application.Services.Handlers.Create;

namespace Hony.Application.Common.Validators;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommandHandler>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Color).NotNull();
        RuleFor(x => x.Color.C).NotNull();
        RuleFor(x => x.Color.L).NotNull();
        RuleFor(x => x.Color.H).NotNull();
    }
}