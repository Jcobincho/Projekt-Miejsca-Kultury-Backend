using Application.Persistance.Interfaces.PostsInterfaces;
using Domain.Entities;

namespace Infrastructure.Persistance.Posts.PostsRepositories;

public class PostsRepository : IPostsRepository
{
    private readonly MiejscaKulturyDbContext _context;

    public PostsRepository(MiejscaKulturyDbContext context)
    {
        _context = context;
    }
    
    public async Task AddPostAsync(Places place, CancellationToken cancellationToken)
    {
        await _context.AddAsync(place, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
    
}