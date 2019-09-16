using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Destructor_Demo
{
    class Program
    {

        static void Main(string[] args)
        {
            Employee john = new Employee("John");
            john.PaySalary();
            john.PayRise();
            john.PaySalary();
            john = null;
            Employee steve = new Employee("Steve");
            steve.PaySalary();
            steve.PayRise();
            steve.PaySalary();
            steve = null;
            GC.AddMemoryPressure(Int32.MaxValue);
            GC.WaitForPendingFinalizers();
            Employee sarah = new Employee("Sarah");
            sarah.PaySalary();
            sarah.PayRise();
            sarah.PaySalary();
            sarah = null;
            Console.ReadLine();
            GC.RemoveMemoryPressure(Int32.MaxValue);
            Console.ReadLine();
        }
    }   
}
