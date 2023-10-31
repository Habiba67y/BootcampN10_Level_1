using Microsoft.AspNetCore.Mvc;
using N66_HT1.Application.Authors;
using N66_HT1.DoMain.Entities;

namespace N66_HT1.Api.Controllers;
[ApiController]
[Route("api/[controller]")]

public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
        var data = _authorService.Get(author => true);

        return data.Any() ? Ok(data) : NotFound();
    }

    [HttpGet("{authorId:guid}")]
    public async ValueTask<IActionResult> GetAuthor(Guid authorId)
    {
        var author = await _authorService.GetByIdAsync(authorId);

        return author != null ? Ok(author) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create(Author author)
    {
        var result = await _authorService.CreateAsync(author);

        return CreatedAtAction(nameof(GetAuthor), new { AuthorId = author.Id }, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update(Author author)
    {
        await _authorService.UpdateAsync(author);

        return NoContent();
    }

    [HttpDelete("{authorId:guid}")]
    public async ValueTask<IActionResult> Delete(Guid authorId)
    {
        await _authorService.DeleteAsync(authorId);

        return NoContent();
    }
}
