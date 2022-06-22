using BackendTemplate.Application.Games.Commands.CreateGame;
using BackendTemplate.Application.Games.Commands.DeleteGame;
using BackendTemplate.Application.Games.Commands.UpdateGame;
using BackendTemplate.Application.Games.Queries.GetGame;
using BackendTemplate.Application.Games.Queries.GetGames;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendTemplate.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/companies/{companyId}/[controller]")]
    public class GamesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetGames(long companyId)
        {
            var query = new GetGamesQuery { CompanyId = companyId };

            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetGame(long id)
        {
            var query = new GetGameQuery { Id = id };

            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<long>> CreateGame(CreateGameCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGame(long id, UpdateGameCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame(long id)
        {
            var command = new DeleteGameCommand { Id = id };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
