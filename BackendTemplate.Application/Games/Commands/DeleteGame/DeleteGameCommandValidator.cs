using FluentValidation;

namespace BackendTemplate.Application.Games.Commands.DeleteGame
{
    public class DeleteGameCommandValidator : AbstractValidator<DeleteGameCommand>
    {
        public DeleteGameCommandValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
