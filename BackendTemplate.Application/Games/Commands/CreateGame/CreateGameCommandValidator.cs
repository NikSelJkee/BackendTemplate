using BackendTemplate.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackendTemplate.Application.Games.Commands.CreateGame
{
    public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateGameCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(p => p.CompanyId)
                .GreaterThan(0).WithMessage("Company id must be greater than 0");

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists");

            RuleFor(p => p.Genre)
                .IsInEnum().WithMessage("Invalid genre value");

            RuleFor(p => p.Info.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(250).WithMessage("Description must not exceed 250 characters");
        }

        private async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _dbContext.Games.AllAsync(p => p.Title != title, cancellationToken);
        }
    }
}
