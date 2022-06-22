using FluentValidation;

namespace BackendTemplate.Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
    {
        public DeleteCompanyCommandValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
