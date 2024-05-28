using FluentValidation;

namespace Application.CQRS.Posts.Commands.AddComment;

public class AddCommentValidator : AbstractValidator<AddCommentCommand>
{
    public AddCommentValidator()
    {
        RuleFor(x => x.Message)
            .NotEmpty().WithMessage("Nie można dodać pustego komentarza!");
    }
}