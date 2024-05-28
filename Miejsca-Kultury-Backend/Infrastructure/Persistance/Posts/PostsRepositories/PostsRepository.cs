using Application.Persistance.Interfaces.PostsInterfaces;
using Domain.Entities;
using Infrastructure.Persistance.Posts.Exceptions;
using Microsoft.EntityFrameworkCore;

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

    public async Task IsPostExistAsync(Guid postId, CancellationToken cancellationToken)
    {
        var post = await _context.Place.FirstOrDefaultAsync(x => x.Id == postId, cancellationToken);

        if (post is null) throw new PostNotFoundException();
    }

    public async Task AddCommentAsync(Comments comment, CancellationToken cancellationToken)
    {
        await _context.Comment.AddAsync(comment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateCommentAsync(Guid userId, Guid commentId, string message, CancellationToken cancellationToken)
    {
        var comment = await _context.Comment.FirstOrDefaultAsync(x => x.Id == commentId, cancellationToken);

        if (comment is null || comment.UsersId != userId) throw new NotAccessToCommentException();

        comment.Message = message;

        _context.Comment.Update(comment);
        await _context.SaveChangesAsync(cancellationToken);
    }
}