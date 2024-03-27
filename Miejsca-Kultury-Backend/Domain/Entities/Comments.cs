namespace Domain.Entities;

public class Comments
{
    public Guid Id { get; set; }
    public string Comment { get; set; }

    public Guid? PlaceId { get; set; }
    public Places Places { get; set; }
    public Guid? UserId { get; set; }
    public User User { get; set; }
}