using FluentValidation;

namespace BackendTemplate.Application.Games.Queries.GetGame
{
    public class GetGameQueryValidator : AbstractValidator<GetGameQuery>
    {
        public GetGameQueryValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
