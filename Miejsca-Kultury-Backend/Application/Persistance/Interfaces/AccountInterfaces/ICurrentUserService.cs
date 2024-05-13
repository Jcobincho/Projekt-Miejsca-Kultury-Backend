namespace Application.Persistance.Interfaces.AccountInterfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }
}