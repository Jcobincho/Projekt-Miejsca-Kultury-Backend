namespace Application.CQRS.Posts.Responses;

public record AddCommentResponse(string Message, Guid CommentId);