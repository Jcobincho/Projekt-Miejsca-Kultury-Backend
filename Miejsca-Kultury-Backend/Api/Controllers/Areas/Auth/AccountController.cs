using Application.CQRS.Account.Commands.ConfirmAccount;
using Application.CQRS.Account.Commands.CreateAccount;
using Application.CQRS.Account.Commands.ResetPassword;
using Application.CQRS.Account.Commands.SignIn;
using Application.CQRS.Account.Events.SendConfirmAccountEmail;
using Application.CQRS.Account.Events.SendResetPasswordEmail;
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);

        return Created("Konto utworzone pomyślnie!", null);
    }

    /// <summary>
    /// Sign in
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken">Email, Password</param>
    /// <returns>Token JWT</returns>
    [HttpPost("/sign-in")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Send email to confirm account
    /// </summary>
    /// <param name="event"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("send-confirm-account-request")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SendConfirmAccountEmail(CancellationToken cancellationToken)
    {
        await Mediator.Send(new SendConfirmAccountEmailEvent(), cancellationToken);

        return Ok("Sprawdź maila");
    }

    /// <summary>
    /// Confirm account
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("confirm-account")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConfirmAccount([FromBody] ConfirmAccountCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);

        return Ok("Pomyślnie zweryfikowano konto!");
    }

    [HttpPost("send-reset-password-request")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SendResetPasswordEmail([FromBody] SendResetPasswordEmailEvent @event, CancellationToken cancellationToken)
    {
        await Mediator.Send(@event, cancellationToken);

        return Ok("Reset hasła możliwy na podanym e-mailu!");
    }

    [HttpPost("reset-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);

        return Ok("Hasło pomyślnie zmienione");
    }
}