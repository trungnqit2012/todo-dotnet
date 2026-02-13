export interface Todo {
  id: string;
  title: string;
  isCompleted: boolean;
}

export async function getTodos(): Promise<Todo[]> {
  const r = await fetch(`/api/todos`);
  return r.json();
}

export async function createTodo(title: string) {
  const r = await fetch(`/api/todos`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(title),
  });
  return r.json();
}

export async function toggleTodo(id: string) {
  await fetch(`/api/todos/${id}/toggle`, { method: "PUT" });
}

export async function deleteTodo(id: string) {
  await fetch(`/api/todos/${id}`, { method: "DELETE" });
}
