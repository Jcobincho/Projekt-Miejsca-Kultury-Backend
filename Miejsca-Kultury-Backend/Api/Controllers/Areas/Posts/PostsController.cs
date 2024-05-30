using Application.CQRS.Account.Static;
using Application.CQRS.Posts.Commands.AddPosts;
using Application.CQRS.Posts.Commands.UpdatePosts;
using Application.CQRS.Posts.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Areas.Posts;

[Route("api/post")]
public class PostsController : BaseController
{
    /// <summary>
    /// Add post by admin
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize(Roles = UserRoles.Admin)]
    [HttpPost("add-posts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddPosts([FromForm] AddPostsCommand command, CancellationToken cancellationToken)
    {
        
        var response = await Mediator.Send(command, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Update posts
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize(Roles = UserRoles.Admin)]
    [HttpPut("update-posts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdatePosts([FromBody] UpdatePostCommand command, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(command, cancellationToken);

        return Ok(response);
    }
}