using FileBaseContext.Abstractions.Models.Entity;
using ToDoList.Common;

namespace ToDoList.Entities;

public class ToDo : Auditable
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
}
