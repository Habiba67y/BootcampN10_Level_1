using Microsoft.AspNetCore.Mvc;
using N63_HT1.Models.Dtos;
using N63_HT1.Services.Interfaces;

namespace N63_HT1.Controllers;
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
}
