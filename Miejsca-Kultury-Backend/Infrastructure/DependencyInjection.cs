using Application.Persistance.Interfaces.AccountInterfaces;
using Domain.Entities;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories.AccountRepositories;
using Infrastructure.Persistance.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,ConfigurationManager configuration)
    {
        services.AddDbContext<MiejscaKulturyDbContext>(options => options.UseNpgsql(
            configuration.GetConnectionString("Database"),
            m => m.MigrationsAssembly("Infrastructure")));

        services.AddScoped<MigrationSeeder>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        
        return services;
    }
}