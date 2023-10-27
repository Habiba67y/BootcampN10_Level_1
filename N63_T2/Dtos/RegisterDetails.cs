using System.ComponentModel.DataAnnotations;

namespace N63_T2.Dtos;

public class RegisterDetails
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}
