import { useEffect, useState } from "react";
import { getTodos, createTodo, toggleTodo, deleteTodo } from "../api/todoApi";
import type { Todo } from "../api/todoApi";

export function useTodos() {
  const [todos, setTodos] = useState<Todo[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const load = async () => {
    try {
      setLoading(true);
      setError(null);
      setTodos(await getTodos());
    } catch {
      setError("Failed to load todos");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    load();
  }, []);

  const add = async (title: string) => {
    await createTodo(title);
    await load();
  };

  const toggle = async (id: string) => {
    await toggleTodo(id);
    await load();
  };

  const remove = async (id: string) => {
    await deleteTodo(id);
    await load();
  };

  return {
    todos,
    loading,
    error,
    add,
    toggle,
    remove,
  };
}
