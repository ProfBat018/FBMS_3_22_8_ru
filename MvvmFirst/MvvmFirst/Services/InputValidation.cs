using MvvmFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmFirst.Services
{
    class InputValidation 
    {
        public static bool ValidatePerson(Person person)
        {
            Regex re = new Regex(@"^[a-zA-Z]+$");

            if (re.IsMatch(person.Name) && re.IsMatch(person.Surname) && person.Age > 18 && person.Age < 150)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
