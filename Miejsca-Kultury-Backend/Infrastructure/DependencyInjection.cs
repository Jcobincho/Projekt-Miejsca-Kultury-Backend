using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,ConfigurationManager configuration)
    {
        services.AddDbContext<Miejsca_KulturyDbContext>(options => options.UseNpgsql(
            configuration.GetConnectionString("Database"),
            m => m.MigrationsAssembly("Infrastructure")));
        return services;
    }
}