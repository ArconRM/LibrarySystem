using LibrarySystem.Dto.Requests;
using LibrarySystem.Extensions;
using LibrarySystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserBookController : ControllerBase
{
    private readonly IUserBookService _userBookService;
    private readonly ILogger<UserBookController> _logger;

    public UserBookController(IUserBookService userBookService, ILogger<UserBookController> logger)
    {
        _userBookService = userBookService;
        _logger = logger;
    }

    /// <summary>
    /// Выдает книгу пользователю.
    /// Проверяет все бизнес-правила.
    /// </summary>
    /// <param name="request">Запрос на займ книги (UserUuid, BookUuid)</param>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Информация о созданном займе</returns>
    [HttpPost(nameof(AddUserBook))]
    public async Task<IActionResult> AddUserBook(UserBookRequest request, CancellationToken token)
    {
        try
        {
            var userBook = await _userBookService.AddNewUserBookAsync(request.UserUuid, request.BookUuid, token);
            var response = userBook.ToResponse();

            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex.Message);
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Возвращает книгу пользователем.
    /// Помечает займ как завершенный, устанавливая дату возврата.
    /// </summary>
    /// <param name="request">Запрос на возврат книги (UserUuid, BookUuid)</param>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Информация о возвращенной книге</returns>
    [HttpDelete(nameof(ReturnUserBook))]
    public async Task<IActionResult> ReturnUserBook(UserBookRequest request, CancellationToken token)
    {
        try
        {
            var userBook =  await _userBookService.ReturnUserBookAsync(request.UserUuid, request.BookUuid, token);
            var response = userBook.ToResponse();
            
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex.Message);
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(new { message = ex.Message });
        }
    }
}