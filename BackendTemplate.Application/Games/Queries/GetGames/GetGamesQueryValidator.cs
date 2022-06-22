using FluentValidation;

namespace BackendTemplate.Application.Games.Queries.GetGames
{
    public class GetGamesQueryValidator : AbstractValidator<GetGamesQuery>
    {
        public GetGamesQueryValidator()
        {
            RuleFor(p => p.CompanyId)
                .GreaterThan(0).WithMessage("Company id must be greater than 0");
        }
    }
}
