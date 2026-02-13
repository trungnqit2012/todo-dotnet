using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Interfaces;
using Todo.Infrastructure.Persistence;

namespace Todo.Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext dbContext;

    public TodoRepository(AppDbContext db)
    {
        dbContext = db;
    }

    public async Task<List<TodoItem>> GetAllAsync()
        => await dbContext.Todos.ToListAsync();

    public async Task<TodoItem?> GetByIdAsync(Guid id)
        => await dbContext.Todos.FindAsync(id);

    public async Task AddAsync(TodoItem todo)
    {
        dbContext.Todos.Add(todo);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TodoItem todo)
    {
        dbContext.Todos.Update(todo);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var todo = await GetByIdAsync(id);
        if (todo is null) return;

        dbContext.Todos.Remove(todo);
        await dbContext.SaveChangesAsync();
    }
}