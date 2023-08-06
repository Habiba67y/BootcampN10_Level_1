using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace N19_HT1
{
    public static class Validator
    {
        public static bool IsValidName(in string Name, out string formattedName)
        {
            formattedName = string.Empty;

            if (string.IsNullOrWhiteSpace(Name))
                return false;

            formattedName = Name.Trim();
            formattedName = string.Concat(
                formattedName.Substring(0, 1).ToUpper(),
                formattedName.Substring(1).ToLower()
                );
            if (Regex.IsMatch(formattedName, @"^[A-z -']+$"))
                return true;

            return false;
        }
        public static bool IsValidEmailAddress(in string emailAddress, out string formattedEmailAddress)
        {
            formattedEmailAddress = string.Empty;

            if (string.IsNullOrWhiteSpace(emailAddress))
                return false;

            formattedEmailAddress = emailAddress.Trim();
            if (Regex.IsMatch(formattedEmailAddress, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                return true;

            return false;
        }
        public static bool IsValidAge(in string age)
        {
            if (string.IsNullOrWhiteSpace(age))
                return false;

            if (Regex.IsMatch(age, @"^(?:1[01][0-9]|120|[1-9][0-9]|[1-9])$"))
                return true;

            return false;
        }
        public static bool IsValidPhone(in string PhoneNumber, out string formattedPhoneNumber)
        {
            formattedPhoneNumber = string.Empty;

            if (string.IsNullOrWhiteSpace(PhoneNumber))
                return false;

            formattedPhoneNumber=PhoneNumber.Trim();
            if (Regex.IsMatch(formattedPhoneNumber, @"^\+\d{1,4}?[-.\s]?\(?\d{1,3}?\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}$"))
                return true;

            return false;
        }
    }
}
