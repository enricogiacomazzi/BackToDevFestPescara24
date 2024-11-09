namespace BackToDevFestPescara24.DTO;

public class Todo
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool Done { get; set; }

    public Todo() { }

    public Todo(string text)
    {
        Text = text;
    }

    public Todo(int id, string text, bool done)
    {
        Id = id;
        Text = text;
        Done = done;
    }
}