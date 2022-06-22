using BackendTemplate.Application.Common.Exceptions;
using BackendTemplate.Application.Common.Interfaces;
using BackendTemplate.Domain.Entities;
using MediatR;

namespace BackendTemplate.Application.Games.Commands.UpdateGame
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateGameCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(
            UpdateGameCommand request, 
            CancellationToken cancellationToken)
        {
            var game = await _dbContext.Games
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (game is null)
            {
                throw new NotFoundException(nameof(Game), request.Id);
            }

            game.Title = request.Title;
            game.Price = request.Price;
            game.Info = request.Info;
            game.Genre = request.Genre;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
