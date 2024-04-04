using Application.Persistance.Interfaces.AccountInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories.AccountRepositories;

public class AccountRepository : IAccountRepository
{
    private readonly MiejscaKulturyDbContext _context;

    public AccountRepository(MiejscaKulturyDbContext context)
    {
        _context = context;
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
}