using BackToDevFestPescara24.DTO;
using BackToDevFestPescara24.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackToDevFestPescara24;

public static class Api
{
    public static void MapApi(this WebApplication app)
    {
        app.MapGet("/api/todos", async (ITodoService ts) => Results.Ok(await ts.GetTodosAsync()));
        
        app.MapGet("/api/todos/{id}", async (int id, ITodoService ts) =>
        {
            var todo = await ts.GetTodoById(id);
            return todo is null ? Results.NotFound() : Results.Ok(todo);
        });


        app.MapPost("/api/todos", async (AddTodo tmp, ITodoService ts) =>
            Results.Created("/api/todos", await ts.AddTodo(new Todo(tmp.text))));

        app.MapPut("/api/todos/{id}", async (int id, [FromBody]Todo todo, ITodoService ts) =>
        {
            todo.Id = id;
            return Results.Ok(await ts.EditTodo(todo));
        });
        
        app.MapDelete("/api/todos/{id}", async (int id, ITodoService ts) =>
        {
            var done = await ts.DeleteTodo(id);
            return done ?  Results.NoContent() : Results.NotFound();
        });
    }
    
    private record AddTodo(string text);
}