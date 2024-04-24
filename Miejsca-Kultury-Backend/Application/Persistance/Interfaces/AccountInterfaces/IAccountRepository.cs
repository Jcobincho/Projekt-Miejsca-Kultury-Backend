using Application.CQRS.Account.Commands.UpdateAccount;
using Domain.Entities;

namespace Application.Persistance.Interfaces.AccountInterfaces;

public interface IAccountRepository
{
    Task<bool> IsEmailExist(string email, CancellationToken cancellationToken);
    Task<Guid> CreateAccount(Users user, CancellationToken cancellationToken);
    Task<string> SignIn(string email, string password, CancellationToken cancellationToken);
    Task<string> RefreshToken(string refreshToken, CancellationToken cancellationToken);
    Task<bool> ResetPassword(string token, string password, CancellationToken cancellationToken);
}