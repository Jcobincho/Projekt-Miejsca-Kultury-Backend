using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Seeders;

public class MigrationSeeder
{
    private readonly MiejscaKulturyDbContext _context;

    public MigrationSeeder(MiejscaKulturyDbContext context)
    {
        _context = context;
    }

    public async Task ApplyPendingMigrations()
    {
        if (await _context.Database.CanConnectAsync() && _context.Database.IsRelational())
        {
            var pendingMigration = await _context.Database.GetPendingMigrationsAsync();
            if (pendingMigration != null && pendingMigration.Any())
            {
                await _context.Database.MigrateAsync();
            }
        }
    }
}