using LibrarySystem.Core.BaseEntities;
using LibrarySystem.Entities;
using LibrarySystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository;

public class UserBookRepository: BaseRepository<UserBook>, IUserBookRepository
{
    private readonly LibraryDbContext _context;
    
    public UserBookRepository(LibraryDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<UserBook>> GetActiveUserBooksAsync(Guid userUuid, CancellationToken token)
    {
        return await _context.UserBooks
            .Where(ub => ub.UserUuid == userUuid && !ub.ReturnedAt.HasValue)
            .ToListAsync(token);
    }

    public async Task<bool> IsBookTakenAsync(Guid bookUuid, CancellationToken token)
    {
        return await _context.UserBooks
            .Where(ub => ub.BookUuid == bookUuid && !ub.ReturnedAt.HasValue)
            .AnyAsync(token);
    }

    public async Task<UserBook> GetUserBookWithBook(Guid userBookUuid, CancellationToken token)
    {
        return await _context.UserBooks
            .Where(ub => ub.Uuid == userBookUuid)
            .Include(ub => ub.Book)
            .FirstOrDefaultAsync(token);
    }
}