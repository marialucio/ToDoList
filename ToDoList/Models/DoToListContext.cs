using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models;

public class ToDoListContext : DbContext
{
    public DbSet<Lista> Listas { get; set; }
    
    public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
    {
        
    }
}