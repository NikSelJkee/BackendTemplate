using FluentValidation;

namespace BackendTemplate.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("UserName is required");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(10).WithMessage("Password must be equal or greater than 10 characters");
        }
    }
}
