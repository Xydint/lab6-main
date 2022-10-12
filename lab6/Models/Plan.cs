using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.Models
{
    public class Plan
    {
        public string Name { get; set; }
        public string Todo { get; set; }
        public DateTimeOffset Date { get; set; }

        public Plan(string name, string todo, DateTimeOffset date)
        {
            Name = name;
            Todo = todo;
            Date = date;
        }

        public override string ToString()
        {
            return Name + " " + Todo + " " + Date.ToString();
        }
    }
}
