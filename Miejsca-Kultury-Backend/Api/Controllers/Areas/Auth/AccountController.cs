using Application.CQRS.Account.Commands.CreateAccount;
using Application.CQRS.Account.Commands.RefreshToken;
using Application.CQRS.Account.Commands.SignIn;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Areas.Auth;

[Route("api")]
public class AccountController : BaseController
{
    /// <summary>
    /// Create Account
    /// </summary>
    /// <param name="command">Name, Surname, Email, Password, RepeatPassword</param>
    /// <param name="cancellationToken"></param>
    /// <returns> New user ID</returns>
    [HttpPost("/register")]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command,
        CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Sign in
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken">Email, Password</param>
    /// <returns>Token JWT</returns>
    [HttpPost("/sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Refresh Token
    /// </summary>
    /// <returns>Token JWT</returns>
    /// <exception cref="UnauthorizedException"></exception>
    [HttpPost("/refresh-token")]
    public async Task<ActionResult<string>> RefreshToken()
    {
        var refreshToken = Request.Cookies[Domain.RefreshToken.RefreshToken.CookieName];
        
        if (refreshToken is null) throw new UnauthorizedException("Token wygasł");
        
        var result = await Mediator.Send(new RefreshTokenCommand(refreshToken));

        return Ok(result);
    }
}