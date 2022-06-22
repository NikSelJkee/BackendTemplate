using BackendTemplate.Application.Common.Exceptions;
using BackendTemplate.Application.Common.Interfaces;
using BackendTemplate.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace BackendTemplate.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtTokenGeneratorService _jwtTokenGeneratorService;

        public IdentityService(
            UserManager<ApplicationUser> userManager, 
            JwtTokenGeneratorService jwtTokenGeneratorService)
        {
            _userManager = userManager;
            _jwtTokenGeneratorService = jwtTokenGeneratorService;
        }

        public async Task<UserPayload> AuthenticationAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var result = (user is not null && await _userManager.CheckPasswordAsync(user, password));

            if (!result)
            {
                throw new AuthenticationException();
            }

            var token = await _jwtTokenGeneratorService.CreateToken(user);

            return new UserPayload(user.Id, user.UserName, user.Email, token);
        }

        public async Task<(Result result, UserPayload user)> CreateUserAsync(string userName, string email, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = email,
            };

            var result = await _userManager.CreateAsync(user, password);

            var jwtToken = await _jwtTokenGeneratorService.CreateToken(user);

            return (result.ToApplicationResult(), new UserPayload(user.Id, user.UserName, user.Email, jwtToken));
        }
    }
}
