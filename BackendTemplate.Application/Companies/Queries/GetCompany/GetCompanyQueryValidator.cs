using FluentValidation;

namespace BackendTemplate.Application.Companies.Queries.GetCompany
{
    public class GetCompanyQueryValidator : AbstractValidator<GetCompanyQuery>
    {
        public GetCompanyQueryValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
