using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicCollection<string> bc = new BasicCollection<string>();
            bc.FillList("One", "Two", "Three", "Four", "Five", "Six","Seven", "Eigth", "Nine", "Ten");

            foreach (string word in bc)
            {
                Console.WriteLine('\t' + word);
            }

            Console.ReadLine();

            foreach (string word in bc.Reverse)
            {
                Console.WriteLine('\t' + word);
            }

            Console.ReadLine();
        }
    }
}
