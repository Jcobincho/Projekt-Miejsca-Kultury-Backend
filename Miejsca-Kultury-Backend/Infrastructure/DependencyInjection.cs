using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.CQRS.Account.Commands.SignIn;
using Application.Persistance.Interfaces.AccountInterfaces;
using Domain.Authentication;
using FluentValidation;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories.AccountRepositories;
using Infrastructure.Persistance.Seeders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,ConfigurationManager configuration)
    {
        services.AddDbContext<MiejscaKulturyDbContext>(options => options.UseNpgsql(
            configuration.GetConnectionString("Database"),
            m => m.MigrationsAssembly(typeof(AssemblyReference).Assembly.ToString())));

        services.AddHttpContextAccessor();
        services.AddScoped<MigrationSeeder>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddValidatorsFromAssemblyContaining<SignInCommand>();
        
        return services;
    }
    
    public static IServiceCollection AddAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        var authenticationSettings = new JwtSettings();
        
        configuration.GetSection(JwtSettings.SectionName).Bind(authenticationSettings);
        services.AddSingleton(authenticationSettings);
        
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = authenticationSettings.Issuer,
                ValidAudience = authenticationSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.Secret))
            };
        });

        return services;
    }
}