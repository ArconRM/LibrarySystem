using LibrarySystem.Core.Interfaces;
using LibrarySystem.Entities;

namespace LibrarySystem.Service.Interfaces;

public interface IUserService: IBaseService<User>
{
    Task<User> SetUserSubscription(Guid userUuid, Subscription subscription, CancellationToken token);
    
    Task<User?> GetUserWithAllInfo(Guid userUuid, CancellationToken token);
}