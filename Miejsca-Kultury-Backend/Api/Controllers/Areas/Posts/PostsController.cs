using Application.CQRS.Account.Static;
using Application.CQRS.Posts.Commands.AddPosts;
using Application.CQRS.Posts.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Areas.Posts;

[Route("api/post")]
public class PostsController : BaseController
{
    [Authorize(Roles = UserRoles.Admin)]
    [HttpPost("add-posts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddPosts([FromForm] AddPostsCommand command, CancellationToken cancellationToken)
    {
        
        var response = await Mediator.Send(command, cancellationToken);

        return Ok(response);
    }
}