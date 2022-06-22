using BackendTemplate.Application.Common.Models;
using MediatR;

namespace BackendTemplate.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<(Result Result, UserPayload user)>
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
