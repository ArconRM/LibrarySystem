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

    [HttpDelete(nameof(DeleteUser))]
    public async Task<IActionResult> DeleteUser(DeleteRequest request, CancellationToken token)
    {
        try
        {
            var isDeleted = await _userService.DeleteAsync(request.Uuid, token);
            return Ok(isDeleted);
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

    // public async Task<IActionResult> GetUser(Guid uuid, CancellationToken token)
    // {
    //     
    // }
}