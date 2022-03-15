using Application.Positions.Queries.QueryTopPositions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class PositionsController : ApiControllerBase
    {
        [HttpGet("Tops7Days")]
        public async Task<ActionResult<List<TopPositionDto>>> Get([FromQuery] GetTop7DaysPositionsQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
