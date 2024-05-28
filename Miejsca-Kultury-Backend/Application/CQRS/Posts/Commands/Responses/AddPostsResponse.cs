namespace Application.CQRS.Posts.Commands.Responses;

public record AddPostsResponse(string Message, Guid PostId);