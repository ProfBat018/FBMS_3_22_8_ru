using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3.Models
{
    public class ToDoItem
    {
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public DateTime DueTime { get; set; }
        public string ImagePath { get; set; }

        public override string ToString()
        {
            return $"{Name} - {DueTime.ToShortDateString()}";
        }
    }
}
