using MediatR;
using BackendTemplate.Application.Common.Interfaces;
using BackendTemplate.Domain.Entities;

namespace BackendTemplate.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, long>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateCompanyCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> Handle(
            CreateCompanyCommand request, 
            CancellationToken cancellationToken)
        {
            var company = new Company { Name = request.Name };

            _dbContext.Companies.Add(company);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return company.Id;
        }
    }
}
