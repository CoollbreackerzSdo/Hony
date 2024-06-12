using FluentValidation;

using Hony.Application.Common.Models;

namespace Hony.Application.Common.Validators;

public class PaginationValidator : AbstractValidator<PaginationEntity>
{
    public PaginationValidator()
    {
        RuleFor(x => x.Count).NotEqual(x => x.Skip).Must(x => x >= 0);
        RuleFor(x => x.Skip).NotEqual(x => x.Count).Must(x => x >= 0);
        RuleFor(x => x.OrderMode).NotNull();
    }
}