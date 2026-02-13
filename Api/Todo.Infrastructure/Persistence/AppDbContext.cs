using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<TodoItem> Todos => Set<TodoItem>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}