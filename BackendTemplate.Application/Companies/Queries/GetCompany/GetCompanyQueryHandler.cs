using AutoMapper;
using BackendTemplate.Application.Common.Exceptions;
using BackendTemplate.Application.Common.Interfaces;
using BackendTemplate.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackendTemplate.Application.Companies.Queries.GetCompany
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCompanyQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CompanyDto> Handle(
            GetCompanyQuery request, 
            CancellationToken cancellationToken)
        {
            var company = await _dbContext.Companies
                .AsNoTracking()
                .Include(c => c.Games)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (company is null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }

            return _mapper.Map<CompanyDto>(company);
        }
    }
}
