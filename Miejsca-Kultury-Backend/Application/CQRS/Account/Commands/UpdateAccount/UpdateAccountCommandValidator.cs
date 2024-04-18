using FluentValidation;

namespace Application.CQRS.Account.Commands.UpdateAccount;

public class UpdateAccountCommandValidator:AbstractValidator<UpdateAccountCommand>
{
    public UpdateAccountCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Wybierz Id");
        RuleFor(x => x.Email).NotEmpty().When(x=>!string.IsNullOrEmpty(x.Email)).EmailAddress().WithMessage("Należy podać poprawny email");
    }
}