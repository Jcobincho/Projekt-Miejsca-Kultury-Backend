using Domain.Exceptions;

namespace Application.CQRS.Account.Exceptions;

public class EmailNotExistException : BaseException
{
    public EmailNotExistException() : base("Taki użytkownik nie istnieje!") { }
}