using BackendTemplate.Domain.Enums;
using BackendTemplate.Domain.ValueObjects;
using MediatR;

namespace BackendTemplate.Application.Games.Commands.CreateGame
{
    public class CreateGameCommand : IRequest<long>
    {
        public long CompanyId { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public GameInfo Info { get; set; } = null!;
        public Genre Genre { get; set; }
    }
}
