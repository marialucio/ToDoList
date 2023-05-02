namespace ToDoList.Models;

public class Lista
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Lista() {}
    
    public Lista(string title, string description)
    {
        Title = title;
        Description = description;
    }
}