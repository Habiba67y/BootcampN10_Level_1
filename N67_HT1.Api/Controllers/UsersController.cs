using Microsoft.AspNetCore.Mvc;
using N67_HT1.Application.UserAccounts.Services;
using N67_HT1.DoMain.Entites;

namespace N67_HT1.Api.Controllers;
[ApiController]
[Route("api/[controller]")]

public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    //private readonly IRoleService _roleService;
    private readonly IUserSettingsService _userSettingsService;

    public UsersController
        (
        IUserService userService,
        //IRoleService roleService,
        IUserSettingsService userSettingsService
        )
    {
        //_roleService = roleService;
        _userSettingsService = userSettingsService;
        _userService = userService;

    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var data = _userService.Get(user => true);

        return data.Any() ? Ok(data) : NotFound();
    }

    [HttpGet("{userId:guid}")]
    public async ValueTask<IActionResult> GetUserById([FromRoute] Guid userId)
    {
        var result = await _userService.GetByIdAsync(userId);

        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateUser([FromBody] User user)
    {
        var result = await _userService.CreateAsync(user);

        return CreatedAtAction(nameof(GetUserById), new { UserId = result.Id }, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateUser([FromBody] User user)
    {
        await _userService.UpdateAsync(user);

        return NoContent();
    }

    [HttpDelete("{userId:guid}")]
    public async ValueTask<IActionResult> DeleteUser([FromRoute] Guid userId)
    {
        await _userService.DeleteByIdAsync(userId);

        return NoContent();
    }

    //[HttpGet("roles")]
    //public IActionResult GetUserRoles()
    //{
    //    var data = _roleService.Get(role => true);

    //    return data.Any() ? Ok(data) : NotFound();
    //}

    //[HttpGet("roles/{roleId:guid}")]
    //public async ValueTask<IActionResult> GetRouteById([FromRoute] Guid roleId)
    //{
    //    var result = await _roleService.GetByIdAsync(roleId);

    //    return result != null ? Ok(result) : NotFound();
    //}

    //[HttpPost("roles")]
    //public async ValueTask<IActionResult> CreateRole([FromBody] Role role)
    //{
    //    var result = await _roleService.CreateAsync(role);

    //    return CreatedAtAction(nameof(GetRouteById), new { RoleId = result.Id }, result);
    //}

    //[HttpPut("roles")]
    //public async ValueTask<IActionResult> UpdateRole([FromBody] Role role)
    //{
    //    var result = await _roleService.UpdateAsync(role);

    //    return NoContent();
    //}

    //[HttpDelete("roles/{roleId: guid}")]
    //public async ValueTask<IActionResult> DeleteRole([FromRoute] Guid roleId)
    //{
    //    var result = await _roleService.DeleteByIdAsync(roleId);

    //    return NoContent();
    //}

    [HttpGet("settings")]
    public IActionResult GetSettings()
    {
        var data = _userSettingsService.Get(settings => true);

        return data.Any() ? Ok(data) : NotFound();
    }

    [HttpGet("settings/settingsId:guid")]
    public async ValueTask<IActionResult> GetSettingsById([FromRoute] Guid settingsId)
    {
        var result = await _userSettingsService.GetByIdAsync(settingsId);

        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost("settings")]
    public async ValueTask<IActionResult> CreateSettings([FromBody] UserSettings settings)
    {
        var result = await _userSettingsService.CreateAsync(settings);

        return CreatedAtAction(nameof(GetSettingsById), new { SettingsId = result.Id }, result);
    }

    [HttpPut("settings")]
    public async ValueTask<IActionResult> UpdateSettings([FromBody] UserSettings settings)
    {
        await _userSettingsService.UpdateAsync(settings);

        return NoContent();
    }

    [HttpDelete("settings/settingsId:guid")]
    public async ValueTask<IActionResult> DeleteSettings([FromRoute] Guid settingsId)
    {
        await _userSettingsService.DeleteByIdAsync(settingsId);

        return NoContent();
    }
}
