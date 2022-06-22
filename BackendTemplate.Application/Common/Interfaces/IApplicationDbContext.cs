using BackendTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTemplate.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Game> Games { get; }

        DbSet<Company> Companies { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}