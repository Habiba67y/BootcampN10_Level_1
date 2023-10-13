using Microsoft.AspNetCore.Mvc;
using N53_HT1.Api.Models;
using N53_HT1.Api.Services.Interfaces;

namespace N53_HT1.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var result = _userService.Get(user => true)
            .ToList();

        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpGet("{userId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid userid)
    {
        var result = await _userService.GetByIdAsync(userid);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] User user)
    {
        var result = await _userService.CreateAsync(user);
        return CreatedAtAction(nameof(GetById), new { userId = result.Id }, result);
    }
}


