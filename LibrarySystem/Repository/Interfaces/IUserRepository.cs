using LibrarySystem.Core.Interfaces;
using LibrarySystem.Entities;

namespace LibrarySystem.Repository.Interfaces;

public interface IUserRepository: IBaseRepository<User>
{
    Task<User?> GetUserWithAllInfo(Guid userUuid, CancellationToken token);

    Task<User?> GetUserWithSubscription(Guid userUuid, CancellationToken token);
}