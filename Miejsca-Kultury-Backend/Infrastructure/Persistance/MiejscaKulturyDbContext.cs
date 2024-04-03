using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class MiejscaKulturyDbContext :DbContext
{
    public MiejscaKulturyDbContext(DbContextOptions<MiejscaKulturyDbContext> options): base(options){}
    
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