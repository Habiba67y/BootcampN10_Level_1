using FileBaseContext.Abstractions.Models.Entity;
using System.Net.Mail;

namespace N48_HT1.Api.Models
{
    public class User : IFileSetEntity<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Password { get; set; }
    }
}
