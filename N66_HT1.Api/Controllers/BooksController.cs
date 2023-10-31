using Microsoft.AspNetCore.Mvc;
using N66_HT1.Application.Authors;
using N66_HT1.Application.Books;
using N66_HT1.DoMain.Entities;

namespace N66_HT1.Api.Controllers;
[ApiController]
[Route("api/[controller]")]

public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        var data = _bookService.Get(book => true);

        return data.Any() ? Ok(data) : NotFound();
    }

    [HttpGet("{bookId:guid}")]
    public async ValueTask<IActionResult> GetBook(Guid bookId)
    {
        var book = await _bookService.GetByIdAsync(bookId);

        return book != null ? Ok(book) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create(Book book)
    {
        var result = await _bookService.CreateAsync(book);

        return CreatedAtAction(nameof(GetBook), new { ContactId = book.Id }, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update(Book book)
    {
        await _bookService.UpdateAsync(book);

        return NoContent();
    }

    [HttpDelete("{bookId:guid}")]
    public async ValueTask<IActionResult> Delete(Guid bookId)
    {
        await _bookService.DeleteAsync(bookId);

        return NoContent();
    }
}
