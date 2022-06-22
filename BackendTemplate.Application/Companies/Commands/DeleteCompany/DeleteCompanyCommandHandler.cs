using MediatR;
using BackendTemplate.Domain.Entities;
using BackendTemplate.Application.Common.Exceptions;
using BackendTemplate.Application.Common.Interfaces;

namespace BackendTemplate.Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteCompanyCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(
            DeleteCompanyCommand request, 
            CancellationToken cancellationToken)
        {
            var company = await _dbContext.Companies
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (company is null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }

            _dbContext.Companies.Remove(company);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
