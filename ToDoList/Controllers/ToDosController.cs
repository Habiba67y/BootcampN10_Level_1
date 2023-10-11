using Microsoft.AspNetCore.Mvc;
using ToDoList.Entities;
using ToDoList.Models;
using ToDoList.Services.Interfaces;

namespace ToDoList.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ToDosController: ControllerBase
{
    private readonly IToDoService _todoService;
    public ToDosController(IToDoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public IActionResult GetToDos([FromQuery] FilterPagination filterPagination)
    {
        var result = _todoService.Get(toDo => true)
            .Skip((filterPagination.PageToken - 1) * filterPagination.PageSize).Take(filterPagination.PageSize)
            .ToList();

        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpGet("{toDoId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid toDoid)
    {
        var result = await _todoService.GetByIdAsync(toDoid);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] ToDo toDo)
    {
        var result = await _todoService.CreateAsync(toDo);
        return CreatedAtAction(nameof(GetById), new { toDoId = result.Id }, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] ToDo toDo)
    {
        var result = await _todoService.UpdateAsync(toDo);
        return NoContent();
    }

    [HttpDelete("{toDoId:guid}")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid toDoId)
    {
        var result = await _todoService.DeleteAsync(toDoId);
        return NoContent();
    }
}
