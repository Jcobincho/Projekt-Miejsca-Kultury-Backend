using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Persistance.Interfaces.AccountInterfaces;
using Domain.Authentication;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Persistance.Repositories.AccountRepositories;

public class AccountRepository : IAccountRepository
{
    private readonly MiejscaKulturyDbContext _context;
    private readonly JwtSettings _jwtSettings;

    public AccountRepository(MiejscaKulturyDbContext context, JwtSettings jwtSettings)
    {
        _context = context;
        _jwtSettings = jwtSettings;
    }
    
    
    public async Task<bool> IsEmailExist(string email, CancellationToken cancellationToken)
    {
        return await _context.User.AnyAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<Guid> CreateAccount(Users user, CancellationToken cancellationToken)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        
        await _context.User.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }

    public async Task<string> SignIn(string email, string password, CancellationToken cancellationToken)
    {
        var user = await _context.User.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

        if (user is null) return null;

        var verifyPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);
        
        if (!verifyPassword) return null;

        var newToken = GenerateToken(user.Id, user.Name, user.Surname);

        return newToken;
    }

    private string GenerateToken(Guid userId, string name, string surname)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, name),
            new Claim(ClaimTypes.Surname, surname)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes);

        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: expires,
            signingCredentials: cred
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}