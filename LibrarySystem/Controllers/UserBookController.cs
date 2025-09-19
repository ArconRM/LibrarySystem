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

    [HttpPost(nameof(AddUserBook))]
    public async Task<IActionResult> AddUserBook(UserBookRequest request, CancellationToken token)
    {
        try
        {
            var userBook = await _userBookService.AddNewUserBookAsync(request.UserUuid, request.BookUuid, token);
            var response = userBook.ToResponse();

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
        }
    }

    [HttpDelete(nameof(ReturnUserBook))]
    public async Task<IActionResult> ReturnUserBook(UserBookRequest request, CancellationToken token)
    {
        try
        {
            var userBook =  await _userBookService.ReturnUserBookAsync(request.UserUuid, request.BookUuid, token);
            var response = userBook.ToResponse();
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
        }
    }
}