using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class MiejscaKulturyDbContext : DbContext
{
    public MiejscaKulturyDbContext(DbContextOptions<MiejscaKulturyDbContext> options): base(options){}
    
    public DbSet<Users> User { get; set; }
    public DbSet<Likes> Like { get; set; }
    public DbSet<Opens> Open { get; set; }
    public DbSet<Photos> Photo { get; set; }
    public DbSet<Places> Place { get; set; }
    public DbSet<Reviews> Review { get; set; }
    public DbSet<Comments> Comment { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}