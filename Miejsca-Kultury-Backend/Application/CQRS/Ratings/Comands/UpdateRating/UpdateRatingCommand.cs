using Application.CQRS.Ratings.Responses;
using Domain.Enums;
using MediatR;

namespace Application.CQRS.Ratings.Comands.UpdateRating;

public record UpdateRatingCommand( 
    Guid PlaceId,
    TypesOfRatings Rating
):IRequest<UpdateRatingResponse>;