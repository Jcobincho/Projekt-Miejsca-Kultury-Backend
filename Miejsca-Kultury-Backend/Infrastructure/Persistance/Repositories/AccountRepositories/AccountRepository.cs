using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.Persistance.Interfaces.AccountInterfaces;
using Domain.Authentication;
using Domain.Entities;
using Domain.RefreshToken;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Persistance.Repositories.AccountRepositories;

public class AccountRepository : IAccountRepository
{
    private readonly MiejscaKulturyDbContext _context;
    private readonly JwtSettings _jwtSettings;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AccountRepository(MiejscaKulturyDbContext context, JwtSettings jwtSettings, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _jwtSettings = jwtSettings;
        _httpContextAccessor = httpContextAccessor;
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
        var refreshToken = GenerateRefreshToken();
        SetRefreshToken(refreshToken, user);

        await _context.SaveChangesAsync(cancellationToken);

        return newToken;
    }

    public async Task<string> RefreshToken(string refreshToken, CancellationToken cancellationToken)
    {
        var user = await _context.User.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken, cancellationToken);

        if (user is null || user.TokenExpires < DateTimeOffset.Now)
        {
            return null;
        }

        var newToken = GenerateToken(user.Id, user.Name, user.Surname);
        var newRefreshToken = GenerateRefreshToken();
        SetRefreshToken(newRefreshToken, user);

        await _context.SaveChangesAsync(cancellationToken);

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

    private RefreshToken GenerateRefreshToken()
    {
        return new RefreshToken
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = DateTimeOffset.Now.AddDays(7)
        };
    }

    private void SetRefreshToken(RefreshToken refreshToken, Users user)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = refreshToken.Expires
        };
        _httpContextAccessor.HttpContext.Response.Cookies.Append(Domain.RefreshToken.RefreshToken.CookieName, refreshToken.Token, cookieOptions);

        user.RefreshToken = refreshToken.Token;
        user.TokenCreated = refreshToken.CreatedAt;
        user.TokenExpires = refreshToken.Expires;
    }
}