using Microsoft.AspNetCore.Mvc;
using N53_HT1.Api.Services.Interfaces;

namespace N53_HT1.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BonusesController : ControllerBase
{
    private readonly IBonusService _bonusService;
    public BonusesController(IBonusService bonusService)
    {
        _bonusService = bonusService;
    }

    [HttpGet]
    public IActionResult GetBonuses()
    {
        var result = _bonusService.Get(bonus => true)
            .ToList();

        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpGet("{bonusId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid bonusid)
    {
        var result = await _bonusService.GetByIdAsync(bonusid);

        return result is not null ? Ok(result) : NotFound();
    }
}
