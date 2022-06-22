using AutoMapper;
using BackendTemplate.Application.Common.Interfaces;
using BackendTemplate.Domain.Entities;
using MediatR;

namespace BackendTemplate.Application.Games.Commands.CreateGame
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, long>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGameCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<long> Handle(
            CreateGameCommand request, 
            CancellationToken cancellationToken)
        {
            var game = new Game
            {
                Title = request.Title,
                Price = request.Price,
                Info = request.Info,
                Genre = request.Genre,
                CompanyId = request.CompanyId
            };

            _dbContext.Games.Add(game);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return game.Id;
        }
    }
}
