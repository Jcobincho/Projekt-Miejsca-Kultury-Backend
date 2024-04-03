namespace Domain.Entities;

public class Places
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int AverageRatings { get; set; }
    public string Category { get; set; }
    public double Localization { get; set; }
}