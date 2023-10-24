using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFirst.Models;
public class Person
{
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public int Age { get; set; }

    public override string ToString()
    {
        return $"{Name}\t{Surname}";
    }
}
