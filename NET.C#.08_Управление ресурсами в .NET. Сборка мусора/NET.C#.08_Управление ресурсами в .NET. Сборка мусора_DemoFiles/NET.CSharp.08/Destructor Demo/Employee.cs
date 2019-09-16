using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Destructor_Demo
{
    class Employee
    {
        string name;
        double salary;

        public Employee(string EmployeeName)
        {
            name = EmployeeName;
            Console.WriteLine("Employee {0} created.", name);
            // Read the current salary from a file. This could be a database.
            salary = Double.Parse(File.ReadAllText("SalaryDetails.txt"));
        }

        public void PaySalary()
        {
            Console.WriteLine("Employee ({0}) paid: {1}", name, salary.ToString());
        }

        public void PayRise()
        {
            salary = salary * 1.1;
        }

        ~Employee()
        {
            // Write the current salary to a file. This could be a database.
            File.WriteAllText("Salary.txt", salary.ToString());
            Console.WriteLine("Employee finalized: {0}", name);
            Console.Beep();
        }
    }
}
