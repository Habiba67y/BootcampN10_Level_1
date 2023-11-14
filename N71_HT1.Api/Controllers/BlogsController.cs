using Microsoft.AspNetCore.Mvc;
using N71_HT1.Application.Common;
using N71_HT1.DoMain.Entities;

namespace N71_HT1.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BlogsController: ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogsController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var result = _blogService.Get();

        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpGet("blogId:guid")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid blogId, CancellationToken cancellation)
    {
        var result = await _blogService.GetByIdAsync(blogId, cancellation: cancellation);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] Blog blog, CancellationToken cancellation) 
    {
        var result = await _blogService.CreateAsync(blog, cancellation: cancellation);

        return CreatedAtAction(nameof(GetById), new { BlogId = result.Id }, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] Blog blog, CancellationToken cancellation)
    {
        await _blogService.UpdateAsync(blog, cancellation: cancellation);

        return NoContent();
    }

    [HttpDelete("blogId:guid")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid blogId, CancellationToken cancellation)
    {
        await _blogService.DeleteByIdAsync(blogId, cancellation: cancellation);

        return NoContent(); 
    }
}
