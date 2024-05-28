using Domain.Entities;

namespace Application.Persistance.Interfaces.PostsInterfaces;

public interface IPostsRepository
{
    Task AddPostAsync(Places place, CancellationToken cancellationToken);
    Task IsPostExistAsync(Guid postId, CancellationToken cancellationToken);
    Task AddCommentAsync(Comments comment, CancellationToken cancellationToken);
}