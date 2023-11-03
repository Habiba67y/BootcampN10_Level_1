using Microsoft.AspNetCore.Mvc;
using N67_HT1.Application.Locations.Servcises;
using N67_HT1.DoMain.Entites;

namespace N67_HT1.Api.Controllers;
[ApiController]
[Route("api/[controller]")]

public class LocationsController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationsController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var data = _locationService.Get(location => true);

        return data.Any() ? Ok(data) : NotFound();
    }

    [HttpGet("{locationId:guid}")]
    public async ValueTask<IActionResult> GetLocation([FromRoute] Guid locationId)
    {
        var result = await _locationService.GetByIdAsync(locationId);

        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] Location location)
    {
        var result = await _locationService.CreateAsync(location);

        return CreatedAtAction(nameof(GetLocation), new { LocationId = result.Id }, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] Location location)
    {
        await _locationService.UpdateAsync(location);

        return NoContent();
    }

    [HttpDelete("{locationId:guid}")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid locationId)
    {
        await _locationService.DeleteByIdAsync(locationId);

        return NoContent();
    }
}
