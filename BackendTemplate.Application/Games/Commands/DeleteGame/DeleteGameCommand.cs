using MediatR;

namespace BackendTemplate.Application.Games.Commands.DeleteGame
{
    public class DeleteGameCommand : IRequest
    {
        public long Id { get; set; }
    }
}
