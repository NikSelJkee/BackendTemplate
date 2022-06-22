using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using BackendTemplate.Application.Common.Interfaces;
using BackendTemplate.Application.Companies.Queries.GetCompany;

namespace BackendTemplate.Application.Companies.Queries.GetCompanies
{
    public class GetCompaniesQueryHandler :
        IRequestHandler<GetCompaniesQuery, IEnumerable<CompanyDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCompaniesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDto>> Handle(
            GetCompaniesQuery request, 
            CancellationToken cancellationToken)
        {
            return await _dbContext.Companies
                .AsNoTracking()
                .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
                .OrderBy(c => c.Name)
                .ToListAsync(cancellationToken);
        }
    }
}
