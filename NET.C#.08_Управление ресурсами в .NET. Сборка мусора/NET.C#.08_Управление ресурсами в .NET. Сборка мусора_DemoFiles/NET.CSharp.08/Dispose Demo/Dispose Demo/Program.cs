using System;

namespace Dispose_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Employee Louise = new Employee("Louise"))
            {
                Louise.PaySalary();
            }

            Console.ReadLine();

            Employee Jane = new Employee("Jane");
            Jane.PaySalary();
            Jane.Dispose();
            Jane.PaySalary();
        }
    }
}
