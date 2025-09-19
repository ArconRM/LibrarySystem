using LibrarySystem.Core.Interfaces;
using LibrarySystem.Entities;

namespace LibrarySystem.Service.Interfaces;

public interface IUserService: IBaseService<User>
{
    /// <summary>
    /// Создает подписку для пользователя
    /// </summary>
    /// <param name="userUuid">ID пользователя</param>
    /// <param name="subscription">Данные подписки (StartDate, EndDate, Price)</param>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Пользователь с созданной подпиской и полной информацией</returns>
    /// <exception cref="InvalidOperationException">При нарушении бизнес-правил</exception>
    Task<User> SetUserSubscription(Guid userUuid, Subscription subscription, CancellationToken token);
    
    /// <summary>
    /// Получает пользователя со всей связанной информацией
    /// Включает подписку, активные займы книг и историю займов
    /// </summary>
    /// <param name="userUuid">ID пользователя</param>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Пользователь с полной информацией или null если не найден</returns>
    Task<User?> GetUserWithAllInfo(Guid userUuid, CancellationToken token);
}