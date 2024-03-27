namespace Domain.Entities;

public class Likes
{
    public Guid Id { get; set; }
    public bool Like { get; set; }

    public Guid? PlaceId { get; set; }
    public Places Places { get; set; }
    public Guid? UserId { get; set; }
    public User User { get; set; }
}