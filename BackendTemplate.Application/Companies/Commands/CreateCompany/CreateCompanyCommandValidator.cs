using BackendTemplate.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendTemplate.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateCompanyCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters")
                .MustAsync(BeUniqueName).WithMessage("The specified name already exists");
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _dbContext.Companies.AllAsync(p => p.Name != name, cancellationToken);
        }
    }
}
