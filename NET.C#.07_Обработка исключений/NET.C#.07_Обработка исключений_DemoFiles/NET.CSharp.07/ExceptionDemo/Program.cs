using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //variant 1
            //Console.Write("x=");
            //int x = int.Parse(Console.ReadLine());
            //int y = 1 / x;
            //Console.WriteLine("y={0}", y);

            //try
            //{
            //    Console.Write("x=");
            //    int x = int.Parse(Console.ReadLine());
            //    int y = 1 / x;
            //    Console.WriteLine("y={0}", y);
            //    Console.WriteLine("блок try выполнился успешно");
            //}
            //catch
            //{
            //    Console.WriteLine("возникла какая-то ошибка");
            //}
            //finally
            //{
            //    Console.WriteLine("блок finally выполнился успешно");
            //}
            //Console.WriteLine("конец программы");

            //variant 2
            //try
            //{
            //    Console.Write("x=");
            //    int x = int.Parse(Console.ReadLine());
            //    int y = 1 / x;
            //    Console.WriteLine("y={0}", y);
            //    Console.WriteLine("блок try выполнился успешно");
            //}
            ////catch (Exception error)
            ////{
            ////    Console.WriteLine("Возникла ошибка {0}", error);
            ////}
            //catch (Exception error)
            //{
            //    Console.WriteLine(error.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("блок finally выполнился успешно");
            //}
            //Console.WriteLine("конец программы");

            //variant 3
            try
            {
                Console.Write("x=");
                int x = int.Parse(Console.ReadLine()); // 1 ситуация
                int y = 1 / x; // 2 ситуация
                Console.WriteLine("y={0}", y);
                Console.WriteLine("блок try выполнился успешно");
            }
            catch (FormatException error) // обработка 1 ситуации
            {
                Console.WriteLine(error.Message);
            }
            catch (DivideByZeroException error) //обработка 2 ситуации
            {
                Console.WriteLine(error.Message);
            }
            Console.WriteLine("конец программы");

            Console.ReadLine();
        }
    }
}
