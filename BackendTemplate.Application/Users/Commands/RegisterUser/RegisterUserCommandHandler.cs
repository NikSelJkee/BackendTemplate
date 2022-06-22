using BackendTemplate.Application.Common.Interfaces;
using BackendTemplate.Application.Common.Models;
using MediatR;

namespace BackendTemplate.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, (Result Result, UserPayload user)>
    {
        private readonly IIdentityService _identityService;

        public RegisterUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<(Result Result, UserPayload user)> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.CreateUserAsync(request.UserName, request.Email, request.Password);

            return result;
        }
    }
}
