using BackendTemplate.Application.Games.Queries.GetGame;
using MediatR;

namespace BackendTemplate.Application.Games.Queries.GetGames
{
    public class GetGamesQuery : IRequest<IEnumerable<GameDto>>
    {
        public long CompanyId { get; set; }
    }
}
