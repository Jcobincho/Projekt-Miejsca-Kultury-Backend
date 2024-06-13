using Application.CQRS.Account.Static;
using Application.CQRS.Ratings.Comands.AddRating;
using Application.CQRS.Ratings.Comands.UpdateRating;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Areas.Ratings;
[Route("api/rating")]
public class RatingController:BaseController
{
    [Authorize(Roles = UserRoles.User)]
    [HttpPost("add-ratting")]
    public async Task<IActionResult> AddRating([FromBody] AddRatingCommand command, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(command, cancellationToken);
        return Ok(response);
    }
    
    
    
    [Authorize(Roles = UserRoles.User)]
    [HttpPut("update-ratting")]
    public async Task<IActionResult> UpdateRating([FromBody] UpdateRatingCommand command, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}