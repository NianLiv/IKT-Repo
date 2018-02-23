using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2_OCP
{
    internal class Employee
    {
        public Employee(string name, uint age, uint salary)
        {
            name_ = name;
            age_ = age;
            salary_ = salary;
        }

        private string name_ { get; set; }
        private uint age_ { get; set; }
        private uint salary_ { get; set; }
    }
}
