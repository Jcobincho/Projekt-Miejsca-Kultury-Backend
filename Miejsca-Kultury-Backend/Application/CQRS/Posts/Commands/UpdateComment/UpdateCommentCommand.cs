using Application.CQRS.Posts.Responses;
using MediatR;

namespace Application.CQRS.Posts.Commands.UpdateComment;

public record UpdateCommentCommand(
    Guid CommentId,
    string NewMessage
    ) : IRequest<UpdateCommentResponse>;