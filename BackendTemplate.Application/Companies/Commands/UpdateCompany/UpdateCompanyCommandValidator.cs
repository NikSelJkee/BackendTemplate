using BackendTemplate.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendTemplate.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateCompanyCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters")
                .MustAsync(BeUniqueName).WithMessage("The specified name already exists");
        }

        private async Task<bool> BeUniqueName(
            UpdateCompanyCommand command, 
            string name, 
            CancellationToken cancellationToken)
        {
            return await _dbContext.Companies
                .Where(p => p.Id == command.Id)
                .AllAsync(p => p.Name != name, cancellationToken);
        }
    }
}
