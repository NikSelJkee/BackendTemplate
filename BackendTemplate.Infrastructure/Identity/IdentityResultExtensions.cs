using BackendTemplate.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace BackendTemplate.Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(
                    result.Errors
                    .GroupBy(e => e.Code)
                    .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup
                        .Select(e => e.Description)
                        .ToArray()));
        }
    }
}
