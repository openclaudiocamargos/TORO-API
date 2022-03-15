using Application.UserPositions.Commands.CreateUserPosition;
using Application.UserPositions.Queries.QueryPatrimony;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class UserPositionsController : ApiControllerBase
    {
        [HttpGet("Patromony")]
        public async Task<ActionResult<UserPatrimonyDto>> Get()
        {
            return await Mediator.Send(new GetPatrimonyQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CreateUserPositionCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
