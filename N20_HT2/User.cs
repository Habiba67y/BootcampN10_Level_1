using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N20_HT2
{
    internal class User
    {
        public string Ism { get; set; }
        public string Familiya { get; set; }
        public string Sharif { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public User(string ism, string familiya, string sharif, string emailAddress, string username)
        {
            Ism = ism;
            Familiya = familiya;
            Sharif = sharif;
            EmailAddress = emailAddress;
            Username = username;
        }

        public bool IsActive { get; set; }
        public override string ToString()
        {
            return $"\nIsm: {Ism}\nFamiliya: {Familiya}\nSharif: {Sharif}\nUsername: {Username}\nEmail: {EmailAddress}";

        }
    }
}
