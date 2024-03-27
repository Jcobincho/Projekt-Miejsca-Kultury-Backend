using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class Miejsca_KulturyDbContext :DbContext
{
    public Miejsca_KulturyDbContext(DbContextOptions<Miejsca_KulturyDbContext> options): base(options){}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Likes> Likes { get; set; }
    public DbSet<Open> Open { get; set; }
    public DbSet<Photos> Photos { get; set; }
    public DbSet<Places> Places { get; set; }
    public DbSet<Reviews> Reviews { get; set; }
    public DbSet<Comments> Comments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}