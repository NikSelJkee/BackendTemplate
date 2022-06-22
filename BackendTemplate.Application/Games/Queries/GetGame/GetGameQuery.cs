using MediatR;

namespace BackendTemplate.Application.Games.Queries.GetGame
{
    public class GetGameQuery : IRequest<GameDto>    
    {
        public long Id { get; set; }
    }
}
