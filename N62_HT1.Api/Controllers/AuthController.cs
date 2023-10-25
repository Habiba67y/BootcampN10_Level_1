using Microsoft.AspNetCore.Mvc;
using N62_HT1.Api.Dtos;
using N62_HT1.Api.Entities;
using N62_HT1.Api.Services;

namespace N62_HT1.Api.Controllers;
[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private TokenGeneratorService tokenGeneratorService;
    public AuthController(TokenGeneratorService tokenGeneratorService)
    {
        this.tokenGeneratorService = tokenGeneratorService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDetails loginDetails)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            EmailAddress = loginDetails.EmailAddress,
            Password = loginDetails.Password,
        };

        var token = tokenGeneratorService.GetToken(user);
        return Ok(token);
    }
}
