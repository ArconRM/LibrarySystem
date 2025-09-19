using LibrarySystem.Core.Interfaces;
using LibrarySystem.Entities;

namespace LibrarySystem.Repository.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    /// <summary>
    /// Получает пользователя со всей связанной информацией.
    /// Включает подписку и займы книг.
    /// </summary>
    /// <param name="userUuid">Идентификатор пользователя</param>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Пользователь с полной информацией</returns>
    Task<User?> GetUserWithAllInfo(Guid userUuid, CancellationToken token);

    /// <summary>
    /// Получает пользователя с его подпиской (Subscription), без информации о книгах.
    /// Используется, например, для проверки наличия активной подписки перед выдачей книги.
    /// </summary>
    /// <param name="userUuid">Идентификатор пользователя</param>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Пользователь с информацией о подписке</returns>
    Task<User?> GetUserWithSubscription(Guid userUuid, CancellationToken token);
}
