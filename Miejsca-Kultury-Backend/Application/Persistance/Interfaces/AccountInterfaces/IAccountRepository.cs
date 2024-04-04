using Domain.Entities;

namespace Application.Persistance.Interfaces.AccountInterfaces;

public interface IAccountRepository
{
    Task<bool> IsEmailExist(string email, CancellationToken cancellationToken);
    Task<Guid> CreateAccount(Users user, CancellationToken cancellationToken);
}