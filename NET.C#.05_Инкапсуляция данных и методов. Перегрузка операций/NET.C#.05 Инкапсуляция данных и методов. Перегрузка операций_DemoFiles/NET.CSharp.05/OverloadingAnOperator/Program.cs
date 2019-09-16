using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverloadingAnOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeDatabase database = new EmployeeDatabase();

            Employee mike = new Employee("Mike");
            database = database + mike;

            database = database + new Employee("James")
            {
                Salary = 500000,
                Department = "HR"
            };

            Employee lisa = new Employee("Lisa");
            database += lisa;

            database += new Employee("John")
            {
                Salary = 125000,
                Department = "HR"
            };

            database += new Employee("Louise")
            {
                Salary = 1500000,
                Department = "Management"
            };

            database += new Employee("Jane")
            {
                Salary = 25000,
                Department = "Support"
            };

            database += new Employee("Jennifer")
            {
                Salary = 50000,
                Department = "Support"
            };

            Employee louise = database["Louise"];

            Console.WriteLine(louise.ToString());

            Console.WriteLine(database["John"].ToString());

            Console.ReadLine();
        }
    }
}
