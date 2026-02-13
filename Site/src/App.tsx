import { useState } from "react";
import { TodoList } from "./components/TodoList";
import { useTodos } from "./hooks/useTodos";

export default function App() {
  const { todos, loading, error, add, toggle, remove } = useTodos();
  const [title, setTitle] = useState("");

  if (loading) return <p>Loading...</p>;
  if (error) return <p style={{ color: "red" }}>{error}</p>;

  return (
    <div style={{ padding: 32 }}>
      <h1>Todo App 📝</h1>

      <input value={title} onChange={(e) => setTitle(e.target.value)} />
      <button
        onClick={async () => {
          if (!title) return;
          await add(title);
          setTitle("");
        }}
      >
        Add
      </button>

      <TodoList todos={todos} onToggle={toggle} onDelete={remove} />
    </div>
  );
}
