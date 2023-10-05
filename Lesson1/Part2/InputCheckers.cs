using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Part2
{
    internal static class InputCheckers
    {
        
        private static Regex snpRegex = new Regex(@"^[a-zA-Z]+$");

        public static bool checkAll(Person person)
        {
            return IsNameValid(person.Name) && IsSurnameValid(person.Surname) && IsBirthDateValid(person.BirthDate);
        }

        public static bool IsNameValid(string name)
        {
            return snpRegex.IsMatch(name);
        }

        public static bool IsSurnameValid(string surname)
        {
            return snpRegex.IsMatch(surname);
        }

        public static bool IsBirthDateValid(DateTime birthDate)
        {
            return birthDate <= DateTime.Now;
        }   
    }
}
