using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods
{
    public static class ArrayHelper
    {
        //public static int Sum(int[] array)
        //{
        //    var result = 0;
        //    foreach (var item in array)
        //    {
        //        result += item;
        //    }
        //    return result;
        //}

        public static int Sum(this int[] array)
        {
            var result = 0;
            foreach (var item in array)
            {
                result += item;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] m = { 3, 4, 6 };
            //Console.WriteLine(ArrayHelper.Sum(m));
            Console.WriteLine(m.Sum());
        }
    }
}
