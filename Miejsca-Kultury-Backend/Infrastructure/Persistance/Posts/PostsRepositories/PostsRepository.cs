using Application.CQRS.Posts.Dtos;
using Application.CQRS.Posts.Extension;
using Application.Persistance.Interfaces.PostsInterfaces;
using Domain.Entities;
using Domain.Enums;
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

    public async Task DeleteCommentAsync(Guid userId, IList<string> roles, Guid commentId, CancellationToken cancellationToken)
    {
        var comment = await _context.Comment.FirstOrDefaultAsync(x => x.Id == commentId, cancellationToken);

        if (comment is null)
        {
            throw new NotAccessToDeleteCommentException();
        }
        else if(roles.Contains("Admin") || comment.UsersId == userId)
        {
            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync(cancellationToken);
        }
        else
        {
            throw new NotAccessToDeleteCommentException();
        }
    }

    public async Task UpdatePostAsync(Guid userId, Guid postId, PlacesCategory placesCategory, string title, string description,
        double localizationX, double localizationY, CancellationToken cancellationToken)
    {
        var post = await _context.Place.FirstOrDefaultAsync(x => x.Id == postId, cancellationToken);

        if (post is null || post.UsersId != userId) throw new HasNoAccessException();

        post.Title = title;
        post.Description = description;
        post.Category = placesCategory;
        post.LocalizationX = localizationX;
        post.LocalizationY = localizationY;

        _context.Place.Update(post);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeletePostAsync(Guid userId, Guid postId, CancellationToken cancellationToken)
    {
        var post = await _context.Place.FindAsync(postId, cancellationToken);

        if (post is null || post.UsersId != userId) throw new HasNoAccessException();

        var comments = _context.Comment.Where(x => x.PlacesId == post.Id).ToList();

        foreach (var comment in comments) 
            _context.Comment.Remove(comment);
        
        _context.Place.Remove(post);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<DisplayPostsDto>> DisplayPostsAsync(PlacesCategory placesCategory, CancellationToken cancellationToken)
    {
        var post = await _context.Place.Include(x => x.images).
            Where(x => x.Category == placesCategory)
            .ToListAsync(cancellationToken);

        return post.Select(x => x.PostAsDto()).ToList();
    }
}