using BackToDevFestPescara24.DTO;

namespace BackToDevFestPescara24.Services;

public interface ITodoService
{
    Task<IEnumerable<Todo>> GetTodosAsync();
    Task<Todo?> GetTodoById(int id);
    Task<Todo> AddTodo(Todo todo);
    Task<Todo> EditTodo(Todo todo);
    Task<bool> DeleteTodo(int id);
}