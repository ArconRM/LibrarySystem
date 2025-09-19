using LibrarySystem.Dto.Requests;
using LibrarySystem.Extensions;
using LibrarySystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController: ControllerBase
{
    private readonly IBookService _bookService;
    private readonly ILogger<BookController> _logger;

    public BookController(IBookService bookService, ILogger<BookController> logger)
    {
        _bookService = bookService;
        _logger = logger;
    }

    [HttpPost(nameof(AddNewBook))]
    public async Task<IActionResult> AddNewBook(AddNewBookRequest request, CancellationToken token)
    {
        try
        {
            var entity = request.ToEntity();
            
            var addedEntity = await _bookService.CreateAsync(entity, token);
            var response = addedEntity.ToResponse();
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest();
        }
    }
}