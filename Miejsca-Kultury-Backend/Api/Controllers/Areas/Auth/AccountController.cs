using Application.CQRS.Account.Commands.CreateAccount;
using Application.CQRS.Account.Commands.SignIn;
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
}