using Application.AmountTransfer.Command.CreateAmountTransferPIX;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AmountTransferController : ApiControllerBase
    {
        [HttpPost("PIX")]
        public async Task<ActionResult<int>> Post(CreateAmountPIXTransferCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
