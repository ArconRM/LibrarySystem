using LibrarySystem.Dto.Requests;
using LibrarySystem.Extensions;
using LibrarySystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }
    
    /// <summary>
    /// Создает нового пользователя в системе.
    /// </summary>
    /// <param name="request">Данные для создания пользователя (FullName, Email, PhoneNumber)</param>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Созданный пользователь</returns>
    [HttpPost(nameof(CreateUser))]
    public async Task<IActionResult> CreateUser(UserRequest request, CancellationToken token)
    {
        try
        {
            var entity = request.ToEntity();

            var createdEntity = await _userService.CreateAsync(entity, token);
            var response = createdEntity.ToResponse();

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
    /// Получает список всех пользователей.
    /// </summary>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Список пользователей</returns>
    [HttpGet(nameof(GetAllUsers))]
    public async Task<IActionResult> GetAllUsers(CancellationToken token)
    {
        try
        {
            var entities = await _userService.GetAllAsync(token);
            var response = entities.Select(entity => entity.ToResponse()).ToList();
            
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
    /// Получает пользователя со всей связанной информацией.
    /// Включает подписку и займы книг.
    /// </summary>
    /// <param name="uuid">Идентификатор пользователя</param>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Пользователь с полной информацией</returns>
    [HttpGet(nameof(GetUserWithAllInfo))]
    public async Task<IActionResult> GetUserWithAllInfo(Guid uuid, CancellationToken token)
    {
        try
        {
            var entity = await _userService.GetUserWithAllInfo(uuid, token);
            var response = entity.ToFullResponse();
            
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
    /// Обновляет информацию о пользователе.
    /// </summary>
    /// <param name="request">Данные для обновления пользователя</param>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Обновленный пользователь</returns>
    [HttpPatch(nameof(UpdateUser))]
    public async Task<IActionResult> UpdateUser(UpdateUserRequest request, CancellationToken token)
    {
        try
        {
            var entity = request.ToEntity();

            var updatedEntity = await _userService.UpdateAsync(entity, token);
            var response = updatedEntity.ToResponse();

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
    /// Устанавливает подписку для пользователя.
    /// </summary>
    /// <param name="request">Данные подписки (UserUuid, StartDate, EndDate, Price)</param>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Пользователь с созданной подпиской</returns>
    [HttpPatch(nameof(SetUserSubscription))]
    public async Task<IActionResult> SetUserSubscription(SetUserSubscriptionRequest request, CancellationToken token)
    {
        try
        {
            var subscriptionEntity = request.ToEntity(); 
            
            var updatedUser = await _userService.SetUserSubscription(request.UserUuid, subscriptionEntity, token);
            var response = updatedUser.ToFullResponse();
            
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
    /// Удаляет пользователя из системы.
    /// </summary>
    /// <param name="uuid">Идентификатор пользователя для удаления</param>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Результат операции удаления</returns>
    [HttpDelete(nameof(DeleteUser))]
    public async Task<IActionResult> DeleteUser(Guid uuid, CancellationToken token)
    {
        try
        {
            var isDeleted = await _userService.DeleteAsync(uuid, token);
            return Ok(isDeleted);
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