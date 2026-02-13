using Todo.Application.Dtos;
using Todo.Application.Interfaces;
using Todo.Domain.Entities;
using Todo.Domain.Interfaces;

namespace Todo.Application.Services;

public sealed class TodoService : ITodoService
{
    private readonly ITodoRepository _repo;

    public TodoService(ITodoRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<TodoDto>> GetAllAsync()
    {
        var todos = await _repo.GetAllAsync();
        return todos.Select(t => new TodoDto
        {
            Id = t.Id,
            Title = t.Title,
            IsCompleted = t.IsCompleted
        }).ToList();
    }

    public async Task<TodoDto> CreateAsync(string title)
    {
        var todo = new TodoItem
        {
            Id = Guid.NewGuid(),
            Title = title
        };

        await _repo.AddAsync(todo);

        return new TodoDto
        {
            Id = todo.Id,
            Title = todo.Title,
            IsCompleted = todo.IsCompleted
        };
    }

    public async Task ToggleAsync(Guid id)
    {
        var todo = await _repo.GetByIdAsync(id)
            ?? throw new Exception("Todo not found");

        todo.IsCompleted = !todo.IsCompleted;
        await _repo.UpdateAsync(todo);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repo.DeleteAsync(id);
    }
}