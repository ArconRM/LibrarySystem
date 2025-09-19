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
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
        }
    }

    [HttpGet(nameof(GetAllUsers))]
    public async Task<IActionResult> GetAllUsers(CancellationToken token)
    {
        try
        {
            var entities = await _userService.GetAllAsync(token);
            var response = entities.Select(entity => entity.ToResponse()).ToList();
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
        }
    }
    
    [HttpGet(nameof(GetUserWithAllInfo))]
    public async Task<IActionResult> GetUserWithAllInfo(Guid uuid, CancellationToken token)
    {
        try
        {
            var entity = await _userService.GetUserWithAllInfo(uuid, token);
            var response = entity.ToFullResponse();
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
        }
    }

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
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
        }
    }

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
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
        }
    }

    [HttpDelete(nameof(DeleteUser))]
    public async Task<IActionResult> DeleteUser(Guid uuid, CancellationToken token)
    {
        try
        {
            var isDeleted = await _userService.DeleteAsync(uuid, token);
            return Ok(isDeleted);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
        }
    }
}