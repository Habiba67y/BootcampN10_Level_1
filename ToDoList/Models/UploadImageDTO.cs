using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models;

public class UploadImageDTO
{
    [Required]
    public IFormFile Image;
}
