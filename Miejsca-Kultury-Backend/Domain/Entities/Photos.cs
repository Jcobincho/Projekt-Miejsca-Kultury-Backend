using System.Reflection.Metadata;

namespace Domain.Entities;

public class Photos
{
    public Guid Id { get; set; }
    public Blob Photo { get; set; }

    public Guid? PlaceId { get; set; }
    public Places Places { get; set; }
}