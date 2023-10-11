using FileBaseContext.Abstractions.Models.Entity;
using ToDoList.Common;

namespace ToDoList.Entities;

public class User : Auditable
{ 
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}
