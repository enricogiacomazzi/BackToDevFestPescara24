using BackToDevFestPescara24.DTO;

namespace BackToDevFestPescara24.Services;

public class TodoService : ITodoService
{
    private List<Todo> _todos;

    public TodoService()
    {
        _todos = new List<Todo>
        {
            new Todo(1, "Fare la spesa", true),
            new Todo(2, "Coccolare i gatti", false),
            new Todo(3, "Studiare Blazor", false),
            new Todo(4, "Comprare il latte", true),
            new Todo(5, "Fare aperitivo", false)
        };
    }

    public Task<IEnumerable<Todo>> GetTodosAsync() => Task.FromResult(_todos.AsEnumerable());

    public Task<Todo?> GetTodoById(int id) => Task.FromResult(_todos.SingleOrDefault(x => x.Id == id));

    public Task<Todo> AddTodo(Todo todo)
    {
        todo.Id = _todos.Count > 0 ? _todos.Max(x => x.Id) + 1 : 1;
        _todos.Add(todo);
        return Task.FromResult(todo);
    }

    public Task<Todo> EditTodo(Todo todo)
    {
        var index = _todos.FindIndex(x => x.Id == todo.Id);
        _todos[index].Text = todo.Text;
        _todos[index].Done = todo.Done;
        return Task.FromResult(_todos[index]);
    }

    public Task<bool> DeleteTodo(int id)
    {
        return Task.FromResult(_todos.RemoveAll(x => x.Id == id) > 0);
    }
}