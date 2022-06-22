using BackendTemplate.Application.Common.Models;
using MediatR;

namespace BackendTemplate.Application.Users.Queries.LoginUser
{
    public class LoginUserQuery : IRequest<UserPayload>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
