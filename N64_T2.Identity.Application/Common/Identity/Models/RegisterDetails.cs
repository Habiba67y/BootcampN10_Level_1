using System.ComponentModel.DataAnnotations;

namespace N64_T2.Identity.Application.Common.Identity.Models;

public class RegisterDetails
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}
