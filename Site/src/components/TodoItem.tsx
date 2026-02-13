import type { Todo } from "../api/todoApi";

type Props = {
  todo: Todo;
  onToggle: (id: string) => void;
  onDelete: (id: string) => void;
};

export function TodoItem({ todo, onToggle, onDelete }: Props) {
  return (
    <li>
      <span
        style={{
          cursor: "pointer",
          textDecoration: todo.isCompleted ? "line-through" : "none",
        }}
        onClick={() => onToggle(todo.id)}
      >
        {todo.title}
      </span>
      <button onClick={() => onDelete(todo.id)}>x</button>
    </li>
  );
}
