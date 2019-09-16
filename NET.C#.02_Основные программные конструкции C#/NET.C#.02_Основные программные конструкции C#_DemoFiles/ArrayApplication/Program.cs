using System;
using System.Collections;

namespace ArrayApplication
{
    class Program
    {
        static void Main(string[] args)
        {
           
            // -------------------------------------------------------- 
            // Creating and Initializing Arrays.
            // -------------------------------------------------------- 

            // Single-dimensional array.
            int[] singleDimension1 = new int[9];
            int[] singleDimension2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Mulidimensional array.
            int[,] multiDimensional1 = new int[5, 5];
            int[,] multiDimensional2 = { 
                                            { 1, 2, 3, 4, 5 }, 
                                            { 6, 7, 8, 9, 10 } 
                                       };

            // Jagged array.
            int[][] JaggedArray = new int[10][];
            JaggedArray[0] = new int[5]; // Can specify different sizes
            JaggedArray[1] = new int[7];

            JaggedArray[9] = new int[21];



            // -------------------------------------------------------- 
            // Common Properties and Methods Exposed by Arrays.
            // -------------------------------------------------------- 

            int[] numbers = { 1, 2, 3, 4, 5 };
            int[] oldNumbers = { 2, 4, 3, 9, 1 };


            // Binary seach example.
            object searchTerm = 3;
            int result = Array.BinarySearch(oldNumbers, searchTerm);

            // Clone example.
            object numbersClone = numbers.Clone();

            // CopyTo example.
            int[] newNumbers = new int[oldNumbers.Length];
            oldNumbers.CopyTo(newNumbers, 0);

            // GetEnumerator example
            IEnumerator results = oldNumbers.GetEnumerator();
            // Or

            foreach (int number in oldNumbers)
            {
            }

            // GetLength example.
            int count = oldNumbers.GetLength(0);

            // GetValue example.
            object value = oldNumbers.GetValue(2);
            // returns the value 3

            // Length example.
            int numberCount = oldNumbers.Length;
            // Returns the value 5

            // Rank example.
            int rank = oldNumbers.Rank;
            // Returns the value 1

            // SetValue example.
            oldNumbers.SetValue(5000, 4);
            // Changes the value 5 to 5000

            // Sort example.
            Array.Sort(oldNumbers);
            // Sorted values: 2 3 4 9 5000
        }
    }
}
