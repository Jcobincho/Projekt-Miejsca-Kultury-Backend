using Application.CQRS.Account.Commands.CreateAccount;
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
}