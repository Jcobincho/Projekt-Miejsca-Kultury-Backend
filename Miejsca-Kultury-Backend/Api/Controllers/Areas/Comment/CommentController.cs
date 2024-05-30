using Application.CQRS.Account.Static;
using Application.CQRS.Comment.Commands.AddComment;
using Application.CQRS.Comment.Commands.DeleteComment;
using Application.CQRS.Comment.Commands.UpdateComment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Areas.Comment;

[Microsoft.AspNetCore.Components.Route("api/comment")]
public class CommentController : BaseController
{
    /// <summary>
    /// Add comment to exists post
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize(Roles = UserRoles.User)]
    [HttpPost("add-comment")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCommentToPost([FromBody] AddCommentCommand command, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(command, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Update exists comment
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize(Roles = UserRoles.User)]
    [HttpPut("update-comment")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentCommand command, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(command, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Delete comment
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize(Roles = UserRoles.User)]
    [HttpDelete("delete-comment")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeteleComment([FromBody] DeleteCommentCommand command, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(command, cancellationToken);

        return Ok(response);
    }

}