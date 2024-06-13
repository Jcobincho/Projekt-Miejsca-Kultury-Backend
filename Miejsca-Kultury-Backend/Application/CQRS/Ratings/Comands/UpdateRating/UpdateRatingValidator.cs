using FluentValidation;

namespace Application.CQRS.Ratings.Comands.UpdateRating;

public class UpdateRatingValidator: AbstractValidator<UpdateRatingCommand>
{
    public UpdateRatingValidator()
    {
        RuleFor(x => x.Rating).IsInEnum().WithMessage("Wybierz ocenę miejsca");
    }
}