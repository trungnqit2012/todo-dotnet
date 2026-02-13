namespace Todo.Domain.Entities;

public sealed class TodoItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}