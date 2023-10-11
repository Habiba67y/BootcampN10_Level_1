using Microsoft.AspNetCore.Mvc;
using ToDoList.Entities;
using ToDoList.Models;
using ToDoList.Services.Interfaces;

namespace ToDoList.Controllers;
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
    public IActionResult GetUsers([FromQuery] FilterPagination filterPagination)
    {
        var result = _userService.Get(user => true)
            .Skip((filterPagination.PageToken - 1) * filterPagination.PageSize).Take(filterPagination.PageSize)
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
        return CreatedAtAction(nameof(GetById),new { userId = result.Id}, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] User user)
    {
        var result = await _userService.UpdateAsync(user);
        return NoContent();
    }

    [HttpDelete("{userId:guid}")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid userId)
    {
        var result =await _userService.DeleteAsync(userId);
        return NoContent();
    }
}
