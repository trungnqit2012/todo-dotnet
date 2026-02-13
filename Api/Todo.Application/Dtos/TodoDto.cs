namespace Todo.Application.Dtos;

public sealed class TodoDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public bool IsCompleted { get; set; }
}