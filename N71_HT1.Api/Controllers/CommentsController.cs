using Microsoft.AspNetCore.Mvc;
using N71_HT1.Application.Common;
using N71_HT1.DoMain.Entities;

namespace N71_HT1.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var result = _commentService.Get();

        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpGet("commentId:guid")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid commentId, CancellationToken cancellation)
    {
        var result = await _commentService.GetByIdAsync(commentId, cancellation: cancellation);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] Comment comment, CancellationToken cancellation)
    {
        var result = await _commentService.CreateAsync(comment, cancellation: cancellation);

        return CreatedAtAction(nameof(GetById), new { BlogId = result.Id }, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] Comment comment, CancellationToken cancellation)
    {
        await _commentService.UpdateAsync(comment, cancellation: cancellation);

        return NoContent();
    }

    [HttpDelete("commentId:guid")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid commentId, CancellationToken cancellation)
    {
        await _commentService.DeleteByIdAsync(commentId, cancellation: cancellation);

        return NoContent();
    }
}

