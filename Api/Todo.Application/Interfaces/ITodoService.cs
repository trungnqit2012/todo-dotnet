using Todo.Application.Dtos;

namespace Todo.Application.Interfaces;

public interface ITodoService
{
    Task<List<TodoDto>> GetAllAsync();
    Task<TodoDto> CreateAsync(string title);
    Task ToggleAsync(Guid id);
    Task DeleteAsync(Guid id);
}