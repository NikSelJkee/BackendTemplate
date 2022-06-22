using BackendTemplate.Application.Common.Exceptions;
using BackendTemplate.Application.Common.Interfaces;
using BackendTemplate.Domain.Entities;
using MediatR;

namespace BackendTemplate.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateCompanyCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(
            UpdateCompanyCommand request, 
            CancellationToken cancellationToken)
        {
            var company = await _dbContext.Companies
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (company is null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }

            company.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
