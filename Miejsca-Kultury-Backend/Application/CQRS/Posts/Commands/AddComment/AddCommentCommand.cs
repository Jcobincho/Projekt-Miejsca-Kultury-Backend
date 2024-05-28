using Application.CQRS.Posts.Responses;
using MediatR;

namespace Application.CQRS.Posts.Commands.AddComment;

public record AddCommentCommand(
    Guid PlaceId,
    string Message
    ) : IRequest<AddCommentResponse>;