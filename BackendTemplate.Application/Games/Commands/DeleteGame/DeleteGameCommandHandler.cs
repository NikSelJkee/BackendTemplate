using BackendTemplate.Application.Common.Exceptions;
using BackendTemplate.Application.Common.Interfaces;
using BackendTemplate.Domain.Entities;
using MediatR;

namespace BackendTemplate.Application.Games.Commands.DeleteGame
{
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteGameCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(
            DeleteGameCommand request, 
            CancellationToken cancellationToken)
        {
            var game = await _dbContext.Games.FindAsync(new object[] { request.Id }, cancellationToken);

            if (game is null)
            {
                throw new NotFoundException(nameof(Game), request.Id);
            }

            _dbContext.Games.Remove(game);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
