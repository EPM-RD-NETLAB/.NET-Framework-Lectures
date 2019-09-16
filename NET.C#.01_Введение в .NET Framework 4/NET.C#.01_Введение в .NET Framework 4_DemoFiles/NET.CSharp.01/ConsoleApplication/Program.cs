using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            int nextCharacter = Console.Read();

            ConsoleKeyInfo key = Console.ReadKey();

            string line = Console.ReadLine();

            Console.Write("Hello there!");

            Console.WriteLine("Hello there!");
            Console.ReadLine();
        }
    }
}
