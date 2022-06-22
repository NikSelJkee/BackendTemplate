using AutoMapper;
using BackendTemplate.Application.Common.Exceptions;
using BackendTemplate.Application.Common.Interfaces;
using BackendTemplate.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackendTemplate.Application.Games.Queries.GetGame
{
    public class GetGameQueryHandler : IRequestHandler<GetGameQuery, GameDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGameQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GameDto> Handle(
            GetGameQuery request, 
            CancellationToken cancellationToken)
        {
            var game = await _dbContext.Games
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            if (game is null)
            {
                throw new NotFoundException(nameof(Game), request.Id);
            }

            return _mapper.Map<GameDto>(game);
        }
    }
}
