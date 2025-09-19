using LibrarySystem.Core.Interfaces;
using LibrarySystem.Entities;

namespace LibrarySystem.Service.Interfaces;

public interface IUserBookService: IBaseService<UserBook>
{
    Task<UserBook> AddNewUserBookAsync(Guid userUuid, Guid bookUuid, CancellationToken token);
    
    Task<UserBook> ReturnUserBookAsync(Guid userUuid, Guid bookUuid, CancellationToken token);
}