using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class MiejscaKulturyDbContext : IdentityDbContext<Users, IdentityRole<Guid>, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    public MiejscaKulturyDbContext(DbContextOptions<MiejscaKulturyDbContext> options): base(options){}
    
    public DbSet<Likes> Like { get; set; }
    public DbSet<Opens> Open { get; set; }
    public DbSet<Photos> Photo { get; set; }
    public DbSet<Places> Place { get; set; }
    public DbSet<Reviews> Review { get; set; }
    public DbSet<Comments> Comment { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}