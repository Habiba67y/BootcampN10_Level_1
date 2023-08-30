using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace N32_T5
{
    public static class CustomValidator
    {
        public static string? IsValidEmailAddress(string? emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                return "Email address is required.";
            }
            if (emailAddress.Length <= 5)
            {
                return "Minimum length is 5";
            }
            if (!Regex.IsMatch(emailAddress, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                return "invalid email";
            }
            return null;
        }
    }
}