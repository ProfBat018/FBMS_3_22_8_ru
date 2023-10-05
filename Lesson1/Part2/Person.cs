using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImagePath { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname} {BirthDate.ToShortDateString()}";
        }
    }
}
