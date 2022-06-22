using AutoMapper;
using AutoMapper.QueryableExtensions;
using BackendTemplate.Application.Common.Interfaces;
using BackendTemplate.Application.Games.Queries.GetGame;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackendTemplate.Application.Games.Queries.GetGames
{
    public class GetGamesQueryHandler : IRequestHandler<GetGamesQuery, IEnumerable<GameDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGamesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameDto>> Handle(
            GetGamesQuery request, 
            CancellationToken cancellationToken)
        {
            return await _dbContext.Games
                .AsNoTracking()
                .ProjectTo<GameDto>(_mapper.ConfigurationProvider)
                .OrderBy(g => g.Title)
                .ToListAsync(cancellationToken);
        }
    }
}
