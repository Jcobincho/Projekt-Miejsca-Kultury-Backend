using Domain.Exceptions;

namespace Application.CQRS.Posts.Exceptions;

public class HasNoAccessException : BaseException
{
    public HasNoAccessException() : base("Nie możesz edytować tego posta!") { }
}