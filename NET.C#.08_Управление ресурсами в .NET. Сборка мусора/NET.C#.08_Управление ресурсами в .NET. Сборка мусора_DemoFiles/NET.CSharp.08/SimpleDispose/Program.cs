using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleDispose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Dispose *****\n");

            MyResourceWrapper rw = new MyResourceWrapper();
            rw.Dispose();
            Console.ReadLine(); 

            //MyResourceWrapper rw = new MyResourceWrapper();
            //if (rw is IDisposable)
            //    rw.Dispose();
            //Console.ReadLine();

            //MyResourceWrapper rw = new MyResourceWrapper();
            //try
            //{
            //    // Использование членов rw. 
            //}
            //finally
            //{
            //    // Обеспечение вызова метод Dispose() в любом случае, 
            //    //в том числе и при возникновении ошибки. 
            //    rw.Dispose();
            //} 

            // Use a comma-delimited list to declare multiple objects to dispose.
            //using (MyResourceWrapper rw = new MyResourceWrapper(), rw2 = new MyResourceWrapper())
            //{
            //    // Use rw and rw2 objects.
            //}
        }
    }
}
