using Microsoft.AspNetCore.Mvc;
using Todo.Application.Interfaces;

namespace Todo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly ITodoService todoService;

    public TodosController(ITodoService service)
    {
        todoService = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await todoService.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] string title)
        => Ok(await todoService.CreateAsync(title));

    [HttpPut("{id}/toggle")]
    public async Task<IActionResult> Toggle(Guid id)
    {
        await todoService.ToggleAsync(id);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await todoService.DeleteAsync(id);
        return NoContent();
    }
}