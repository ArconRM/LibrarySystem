using LibrarySystem.Core.Interfaces;
using LibrarySystem.Entities;

namespace LibrarySystem.Service.Interfaces;

public interface IUserBookService: IBaseService<UserBook> 
{
    /// <summary>
    /// Выдает книгу пользователю с проверкой всех бизнес-правил
    /// </summary>
    /// <param name="userUuid">ID пользователя</param>
    /// <param name="bookUuid">ID книги</param>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Созданный займ книги с загруженной информацией о книге</returns>
    /// <exception cref="InvalidOperationException">При нарушении бизнес-правил</exception>
    Task<UserBook> AddNewUserBookAsync(Guid userUuid, Guid bookUuid, CancellationToken token);
    
    /// <summary>
    /// Возвращает книгу пользователем
    /// </summary>
    /// <param name="userUuid">ID пользователя</param>
    /// <param name="bookUuid">ID книги для возврата</param>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Обновленный займ книги с датой возврата</returns>
    /// <exception cref="InvalidOperationException">При нарушении бизнес-правил</exception>
    Task<UserBook> ReturnUserBookAsync(Guid userUuid, Guid bookUuid, CancellationToken token);
}