using LibrarySystem.Core.BaseEntities;
using LibrarySystem.Entities;
using LibrarySystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly LibraryDbContext _context;

    public UserRepository(LibraryDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetUserWithSubscription(Guid userUuid, CancellationToken token)
    {
        return await _context.Users
            .AsNoTracking()
            .Include(u => u.Subscription)
            .FirstOrDefaultAsync(u => u.Uuid == userUuid, token);
    }

    public async Task<User?> GetUserWithAllInfo(Guid userUuid, CancellationToken token)
    {
        return await _context.Users
            .AsNoTracking()
            .Include(u => u.Subscription)
            .Include(u => u.UserBooks)
                .ThenInclude(ub => ub.Book)
            .FirstOrDefaultAsync(u => u.Uuid == userUuid, token);
    }
}