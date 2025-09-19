using LibrarySystem.Core.Interfaces;
using LibrarySystem.Entities;

namespace LibrarySystem.Repository.Interfaces;

public interface IUserBookRepository: IBaseRepository<UserBook>
{
    Task<List<UserBook>> GetActiveUserBooksAsync(Guid userUuid, CancellationToken token);
    
    Task<bool> IsBookTakenAsync(Guid bookUuid, CancellationToken token);

    Task<UserBook> GetUserBookWithBook(Guid userBookUuid, CancellationToken token);
}