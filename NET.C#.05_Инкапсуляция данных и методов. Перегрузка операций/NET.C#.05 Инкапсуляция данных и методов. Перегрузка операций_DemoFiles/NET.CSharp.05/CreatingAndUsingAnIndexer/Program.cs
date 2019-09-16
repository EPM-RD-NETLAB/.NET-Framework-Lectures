using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreatingAndUsingAnIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeDatabase database = new EmployeeDatabase();
            database.AddToDatabase(new Employee("John")
            {
                Salary = 125000,
                Department = "HR"
            });
            database.AddToDatabase(new Employee("James")
            {
                Salary = 500000,
                Department = "HR"
            });
            database.AddToDatabase(new Employee("Louise")
            {
                Salary = 1500000,
                Department = "Management"
            });
            database.AddToDatabase(new Employee("Jane")
            {
                Salary = 25000,
                Department = "Support"
            });
            database.AddToDatabase(new Employee("Jennifer")
            {
                Salary = 50000,
                Department = "Support"
            });

            Employee louise = database["Louise"];

            Console.WriteLine(louise.ToString());

            Console.WriteLine(database["John"].ToString());

            Console.ReadLine();
        }
    }
}
