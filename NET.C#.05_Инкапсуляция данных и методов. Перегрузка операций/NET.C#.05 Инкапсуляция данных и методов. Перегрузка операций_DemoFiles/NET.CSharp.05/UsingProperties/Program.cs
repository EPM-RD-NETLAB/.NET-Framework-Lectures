using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsingProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee julie = new Employee("Julie");
            julie.Salary = 125000;
            julie.Department = "HR";

            Employee james = new Employee("James")
            {
                Salary = 120000,
                Department = "Technical"
            };

            Console.WriteLine(james.ToString());
            Console.WriteLine(julie.ToString());

            Console.ReadLine();

            james.Salary = -125000;
            Console.WriteLine(james.ToString());

            Console.ReadLine();
        }
    }
}
