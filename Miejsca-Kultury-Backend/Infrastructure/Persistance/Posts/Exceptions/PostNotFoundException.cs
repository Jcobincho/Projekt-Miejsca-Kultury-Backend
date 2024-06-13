using Domain.Exceptions;

namespace Infrastructure.Persistance.Posts.Exceptions;

public class PostNotFoundException : BaseException
{
    public PostNotFoundException() : base("Wybrany post nie istnieje!") { }
}