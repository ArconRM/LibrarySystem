using LibrarySystem.Core.Interfaces;
using LibrarySystem.Entities;

namespace LibrarySystem.Repository.Interfaces;

public interface IUserBookRepository : IBaseRepository<UserBook>
{
    /// <summary>
    /// Получает все активные книги пользователя (ReturnedAt == null).
    /// </summary>
    /// <param name="userUuid">Идентификатор пользователя, для которого ищем книги.</param>
    /// <param name="token">Токен отмены операции для асинхронного выполнения.</param>
    Task<List<UserBook>> GetActiveUserBooksAsync(Guid userUuid, CancellationToken token);

    /// <summary>
    /// Проверяет, выдана ли книга кому-то.
    /// </summary>
    /// <param name="bookUuid">Идентификатор книги, проверяемой на занятость</param>
    /// <param name="token">Токен отмены операции</param>
    Task<bool> IsBookTakenAsync(Guid bookUuid, CancellationToken token);

    /// <summary>
    /// Получает запись о займе вместе с информацией о книге.
    /// </summary>
    /// <param name="userBookUuid">Идентификатор записи выдачи книги</param>
    /// <param name="token">Токен отмены операции</param>
    Task<UserBook> GetUserBookWithBook(Guid userBookUuid, CancellationToken token);
}
