namespace Domain.RefreshToken;

public class RefreshToken
{
    public const string CookieName = "refreshToken";
    public required string Token { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset Expires { get; set; }
}