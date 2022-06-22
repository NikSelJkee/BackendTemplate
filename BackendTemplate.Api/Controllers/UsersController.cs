using BackendTemplate.Application.Users.Commands.RegisterUser;
using BackendTemplate.Application.Users.Queries.LoginUser;
using Microsoft.AspNetCore.Mvc;

namespace BackendTemplate.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand command)
        {
            var (Result, User) = await Mediator.Send(command);

            return Result.Succeeded ? Ok(User) : BadRequest(Result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
