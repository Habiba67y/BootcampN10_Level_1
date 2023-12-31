﻿using Microsoft.AspNetCore.Mvc;
using N63_T2.Dtos;
using N63_T2.Services;

namespace N63_T2.Controllers;
[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    public AuthController(AuthService authService)
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
