using FluentValidation;
using FluentValidation.Validators;

namespace BackendTemplate.Application.Users.Queries.LoginUser
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage(u => $"Email '{u.Email}' is invalid");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(10).WithMessage("Password must be equal or greater than 10 characters");
        }
    }
}
