using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Persistance.Interfaces.AccountInterfaces;
using Domain.Authentication;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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


    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Users> FindUserAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public JsonWebToken GenerateJwtToken(Guid userId, string email, ICollection<string> roles, ICollection<Claim> claims)
    {
        var now = DateTime.UtcNow;
        
        var jwtClaims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString())
        };

        if (roles?.Any() is true)
        {
            foreach (var role in roles)
            {
                jwtClaims.Add(new Claim(ClaimTypes.Role, role));
            }
        }

        if (claims?.Any() is true)
        {
            var customClaims = new List<Claim>();
            foreach (var claim in claims)
            {
                customClaims.Add(new Claim(claim.Type, claim.Value));
            }
            jwtClaims.AddRange(customClaims);
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = now.AddMinutes(_jwtSettings.ExpiryMinutes);

        var jwt = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            jwtClaims,
            expires: expires,
            signingCredentials: cred
            );

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new JsonWebToken
        {
            AccessToken = token,
            Expires = new DateTimeOffset(expires).ToUnixTimeSeconds(),
            UserId = userId,
            Email = email,
            Roles = roles,
            Claims = claims?.ToDictionary(x => x.Type, c => c.Value)
        };
    }
}