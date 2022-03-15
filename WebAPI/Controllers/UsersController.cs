using Application.Users.Commands.CreateUser;
using Application.Users.Queries;
using Application.Users.Queries.QueryLogin;
using Application.Users.Queries.QueryUserInformations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class UsersController : ApiControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserInformationsDto>> Get()
        {
            return await Mediator.Send(new GetUserInformationsQuery());
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(GetTokenQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> Create(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
