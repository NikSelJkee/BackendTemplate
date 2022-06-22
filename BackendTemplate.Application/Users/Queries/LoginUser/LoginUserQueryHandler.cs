using BackendTemplate.Application.Common.Interfaces;
using BackendTemplate.Application.Common.Models;
using MediatR;

namespace BackendTemplate.Application.Users.Queries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserPayload>
    {
        private readonly IIdentityService _identityService;

        public LoginUserQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<UserPayload> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _identityService.AuthenticationAsync(request.Email, request.Password);

            return user;
        }
    }
}
