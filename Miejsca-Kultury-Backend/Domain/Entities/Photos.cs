using System.Reflection.Metadata;

namespace Domain.Entities;

public class Photos
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string MinioPath { get; set; }
    public string Description { get; set; }
    public long FileSize { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public Guid? PlaceId { get; set; }
    public Places Places { get; set; }
}