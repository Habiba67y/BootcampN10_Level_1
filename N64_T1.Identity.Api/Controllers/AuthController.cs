using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N64_T2.Identity.Application.Common.Constants;
using N64_T2.Identity.Application.Common.Identity.Models;
using N64_T2.Identity.Application.Common.Identity.Services;

namespace N63_T2.Controllers;
[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public async ValueTask<IActionResult> Register([FromBody] RegisterDetails registerDetails)
    {
        var data = await _authService.Register(registerDetails);
        return data ? Ok(data) : BadRequest();
    }

    [HttpPost("Login")]
    public async ValueTask<IActionResult> Login([FromBody] LoginDetails loginDetails) 
    {
        var data = await _authService.Login(loginDetails);
        return data != null ? Ok(data) : NotFound();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("users/{userId:guid}/roles/{roleType}")]
    public async ValueTask<IActionResult> GrandRole([FromRoute] Guid userId, [FromRoute] string roleType, CancellationToken cancellation)
    {
        var actionUserId = Guid.Parse(User.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimConstant.UserId)).Value);
        var result = await _authService.GrandRoleAsync(userId, roleType, actionUserId, cancellation);

        return result ? Ok(result) : BadRequest();
    }
}
