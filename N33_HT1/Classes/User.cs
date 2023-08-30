using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N33_HT1.Classes
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Admin { get; set; }

        public DateTime CreatedDate { get; set; }

        public User(string firstname, string lastname, bool admin)
        {
            Id = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastname;
            Admin = admin;
            CreatedDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Firstname: {FirstName}, Lastname: {LastName}, Admin: {Admin}, Created: {CreatedDate}";
        }
    }
}
