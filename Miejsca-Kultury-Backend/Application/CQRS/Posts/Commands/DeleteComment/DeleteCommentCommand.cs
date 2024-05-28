using Application.CQRS.Posts.Responses;
using MediatR;

namespace Application.CQRS.Posts.Commands.DeleteComment;

public record DeleteCommentCommand(
    Guid CommentId
    ) : IRequest<DeleteCommentResponse>;