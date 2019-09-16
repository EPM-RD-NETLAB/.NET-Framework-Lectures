using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodRefactorAndTestDemo
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        int min = 48;
    //        int max = 50;
    //        int numberOfRequirednumbers = 100;

    //        int[] randomNumbers = new int[numberOfRequirednumbers];

    //        Random numberGenerator = new Random();

    //        for (int count = 0; count < numberOfRequirednumbers; count++)
    //        {
    //            randomNumbers[count] = numberGenerator.Next(min, max);
    //        }

    //        // More logic that use the randomNumbers variable.
    //        Array.Sort(randomNumbers);

    //        Console.ReadLine();
    //    }
    //}

    public class Program
    {
        public static void Main(string[] args)
        {
            int min = 48;
            int max = 50;
            int numberOfRequirednumbers = 100;

            int[] randomNumbers = GenerateRandomNumbers(min, max, numberOfRequirednumbers);

            // More logic that use the randomNumbers variable.
            Array.Sort(randomNumbers);
        }

        private static int[] GenerateRandomNumbers(int min, int max, int numberOfRequirednumbers)
        {
            int[] randomNumbers = new int[numberOfRequirednumbers];

            Random numberGenerator = new Random();

            for (int count = 0; count < numberOfRequirednumbers; count++)
            {
                randomNumbers[count] = numberGenerator.Next(min, max);
            }
            return randomNumbers;
        }

    }
}
