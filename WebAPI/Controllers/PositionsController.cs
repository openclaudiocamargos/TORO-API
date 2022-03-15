using Application.Positions.Queries.QueryAllPositions;
using Application.Positions.Queries.QueryTopPositions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class PositionsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<PositionDto>>> GetAll()
        {
            return await Mediator.Send(new GetAllPositionsQuery());
        }

        [HttpGet("Tops7Days")]
        public async Task<ActionResult<List<TopPositionDto>>> GetTops([FromQuery] GetTop7DaysPositionsQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
