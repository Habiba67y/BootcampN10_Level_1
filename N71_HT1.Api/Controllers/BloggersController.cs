using Microsoft.AspNetCore.Mvc;
using N71_HT1.Application.Common;
using N71_HT1.DoMain.Entities;

namespace N71_HT1.Api.Controllers;
[ApiController]
[Route("api/[controller]")]

public class BloggersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IBloggerManagementService _bloggerManagementService;

    public BloggersController
        (
        IUserService userService,
        IBloggerManagementService bloggerManagementService
        )
    {
        _userService = userService;
        _bloggerManagementService = bloggerManagementService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        Console.WriteLine("iuytrdsxcdfvghj");
        var result = _userService.Get();

        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpGet("{bloggerId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid bloggerId, CancellationToken cancellation)
    {
        var result = await _userService.GetByIdAsync(bloggerId, cancellation: cancellation);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpGet("popular")]
    public async ValueTask<IActionResult> GetPopularBloggers(CancellationToken cancellation)
    {
        var result = await _bloggerManagementService.GetPopularBloggers(cancellation: cancellation);

        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] User user,  CancellationToken cancellation)
    {
        var result = await _userService.CreateAsync(user, cancellation: cancellation);

        return CreatedAtAction(nameof(GetById), new { BloggerId = result.Id}, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] User user, CancellationToken cancellation)
    {
        await _userService.UpdateAsync(user, cancellation: cancellation);

        return NoContent();
    }

    [HttpDelete("{bloggerId:guid}")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid bloggerId, CancellationToken cancellation)
    {
        await _userService.DeleteByIdAsync(bloggerId, cancellation: cancellation);

        return NoContent();
    }
}
