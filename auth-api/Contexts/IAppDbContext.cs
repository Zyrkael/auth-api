using auth_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace auth_api.Contexts;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
