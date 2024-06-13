using Application.CQRS.Posts.Dtos;
using Domain.Entities;

namespace Application.CQRS.Posts.Extension;

public static class Extension
{
    public static DisplayPostsDto PostAsDto(this Places post)
    {
        var ulrList = new List<string>();

        foreach (var image in post.images)
        {
            ulrList.Add(image.Url);
        }
        double averageRating = post.Ratings.Any() ? post.Ratings.Average(r => (int)r.Rating) : 0;
        return new DisplayPostsDto
        {
            Id = post.Id,
            Title = post.Title,
            Description = post.Description,
            LocalizationX = post.LocalizationX,
            LocalizationY = post.LocalizationY,
            AverageRating = averageRating,
            Images = ulrList
        };
    }
}