using Domain.Entities;

namespace Application.Persistance.Interfaces.PostsInterfaces;

public interface IPostsRepository
{
    Task AddPostAsync(Places place, CancellationToken cancellationToken);
}