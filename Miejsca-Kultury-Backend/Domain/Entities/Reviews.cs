namespace Domain.Entities;

public class Reviews
{
    public Guid Id { get; set; }
    public int Review { get; set; }

    public Guid? PlaceId { get; set; }
    public Places Places { get; set; }
    public Guid? UserId { get; set; }
    public User User { get; set; }
}