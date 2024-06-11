using Application.CQRS.Comment.Dtos;
using Application.CQRS.Posts.Dtos;
using Domain.Entities;
using Domain.Enums;

namespace Application.Persistance.Interfaces.PostsInterfaces;

public interface IPostsRepository
{
    Task AddPostAsync(Places place, CancellationToken cancellationToken);
    Task IsPostExistAsync(Guid postId, CancellationToken cancellationToken);
    Task AddCommentAsync(Comments comment, CancellationToken cancellationToken);
    Task UpdateCommentAsync(Guid userId, Guid commentId, string message, CancellationToken cancellationToken);
    Task DeleteCommentAsync(Guid userId, IList<string> roles, Guid commentId, CancellationToken cancellationToken);
    Task UpdatePostAsync(Guid userId, Guid postId, PlacesCategory placesCategory, string title, string description, double localizationX, double localizationY, CancellationToken cancellationToken);
    Task DeletePostAsync(Guid userId, Guid postId, CancellationToken cancellationToken);
    Task<List<DisplayPostsDto>> DisplayPostsAsync(PlacesCategory placesCategory, CancellationToken cancellationToken);
    Task<List<CommentDto>> DisplayCommentAsync(Guid postId, CancellationToken cancellationToken);
}