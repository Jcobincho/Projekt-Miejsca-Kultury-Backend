using System.Security.Claims;
using Domain.Authentication;
using Domain.Entities;

namespace Application.Persistance.Interfaces.AccountInterfaces;

public interface IAccountRepository
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    Task<Users> FindUserAsync(string email, CancellationToken cancellationToken);
    JsonWebToken GenerateJwtToken(Guid userId, string email, ICollection<string> roles, ICollection<Claim> claims);
}