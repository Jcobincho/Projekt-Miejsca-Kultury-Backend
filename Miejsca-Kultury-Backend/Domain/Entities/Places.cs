using Domain.Enums;

namespace Domain.Entities;

public class Places
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    //Tu ma być prop do komentarzy
    //Tu ma być prop do lików
    public PlacesCategory Category { get; set; }
    public double LocalizationX { get; set; }
    public double LocalizationY { get; set; }
    
    public Guid? UsersId { get; set; }
    public Users Users { get; set; }
    
    public List<Postimage> images { get; set; }
    public List<Ratings> ratings { get; set; }
}