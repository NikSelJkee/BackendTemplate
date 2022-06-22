using BackendTemplate.Application.Common.Models;

namespace BackendTemplate.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<(Result result, UserPayload user)> CreateUserAsync(string userName, string email, string password);
        Task<UserPayload> AuthenticationAsync(string email, string password);
    }
}
