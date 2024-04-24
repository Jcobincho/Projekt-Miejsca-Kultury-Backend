using FluentValidation;

namespace Application.CQRS.Account.Commands.UpdateAccount;

public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    public UpdateAccountCommandValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty().WithMessage("Coś poszło nie tak!");
        RuleFor(x => x.NewPassword)
            .Equal(e => e.ConfirmPassword)
            .WithMessage("Hasła się różnią!");
    }
}