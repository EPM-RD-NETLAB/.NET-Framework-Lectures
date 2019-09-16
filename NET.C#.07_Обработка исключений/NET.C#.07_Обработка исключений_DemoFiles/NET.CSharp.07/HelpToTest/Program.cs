//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;

//namespace ConsoleApplication1
//{

//    internal class Test
//    {
//        //    private static void Main(string[] args)
//        //    {
//        //        unchecked
//        //        {
//        //            int i = -1;
//        //            Console.WriteLine((byte)i);
//        //        }
//        //    }


//        private static void Main(string[] args)
//        {
//            //unchecked
//            //{
//            //    int i = 256;
//            //    byte b = (byte)i;
//            //    Console.WriteLine((int)b + " ");
//            //}

//            unchecked
//            {
//                short s = short.MinValue;
//                char c = (char)s;
//                Console.WriteLine((int)c);
//            }

//        }

//        //public int m1(bool b)
//        //{
//        //    throw new Exception("Some Exception");
//        //}

//        //private static void Main(string[] args)
//        //{
//        //    StringBuilder word = null;
//        //    int i = 0;
//        //    if (args.Length > 0)
//        //    {
//        //        try
//        //        {
//        //            i = Int32.Parse(args[0]);
//        //        }
//        //        catch
//        //        {
//        //            i = 1;
//        //        }
//        //    }
//        //    switch (i)
//        //    {
//        //        case 1:
//        //            word = new StringBuilder("P");
//        //            break;

//        //        case 2:
//        //            word = new StringBuilder("G");
//        //            break;

//        //        default:
//        //            word = new StringBuilder("M");
//        //            break;
//        //    }
//        //    word.Append('a');
//        //    word.Append('i');
//        //    word.Append('n');
//        //    Console.WriteLine(word);
//        //}

//        //public const int END = int.MaxValue;
//        //public const int START = END - 10;

//        //private static void Main(string[] args)
//        //{
//        //    int count = 0;
//        //    unchecked
//        //    {
//        //        for (int i = START; i <= END; i++)
//        //        {
//        //            count++;
//        //        }   
//        //    }

//        //    Console.WriteLine(count);
//        //}


//        //private static void Main(string[] args)
//        //{
//        //    //unchecked
//        //    //{
//        //    //    int i = int.MaxValue;
//        //    //    i++;
//        //    //    Console.WriteLine(i);
//        //    //}

//        //    //try
//        //    //{
//        //    //    Console.Write("Hello ");
//        //    //    return;
//        //    //}
//        //    //finally
//        //    //{
//        //    //    Console.Write("Goodbye ");
//        //    //}
//        //    //Console.Write("world!");

//        //    //try
//        //    //{
//        //    //    Console.Write("Hello ");
//        //    //    Thread.CurrentThread.Abort();
//        //    //}
//        //    //finally
//        //    //{
//        //    //    Console.Write("Goodbye ");
//        //    //}
//        //    //Console.Write("world!");

//        //    try
//        //    {
//        //        Console.WriteLine("Hello ");
//        //        System.Environment.Exit(0);
//        //    }
//        //    finally
//        //    {
//        //        Console.WriteLine("Goodbye ");
//        //    }
//        //    Console.WriteLine("world!");

//        //}

//        //private static void Main(string[] args)
//        //{
//        //    checked
//        //    {
//        //        Console.WriteLine(8 << 32);
//        //        Console.WriteLine(8 << 33);
//        //    }
//        //}

//        //private static void Main(string[] args)
//        //{
//        //    int i = 0;
//        //    unchecked
//        //    {
//        //        while (-1 << i != 0)
//        //            i++;
//        //    }
//        //    Console.WriteLine(i);
//        //}

//        //private static void Main(string[] args)
//        //{
//        //    checked
//        //    {
//        //        double i = 0.0 / 0.0;

//        //        if (i != i)
//        //            Console.WriteLine("not equal");
//        //        else
//        //            Console.WriteLine("equal");
//        //    }
//        //}

//        //private static void Main(string[] args)
//        //{
//        //    //int i = int.MinValue;
//        //    //unchecked
//        //    //{
//        //    //    if (i != 0 && i == -i)
//        //    //    {
//        //    //        Console.WriteLine("equal");
//        //    //    }
//        //    //    else
//        //    //    {
//        //    //        Console.WriteLine("not equal");
//        //    //    }
//        //    //}

//        //    //checked
//        //    //{
//        //    //    const int START = 2000000000;

//        //    //    float f = START + 50;

//        //    //    if (f == START)
//        //    //        Console.WriteLine("true");
//        //    //    else
//        //    //        Console.WriteLine("false");
//        //    //}
//        //}
//        //private static int i = -(2147483648);

//        //private static void Main(string[] args)
//        //{
//        //    checked
//        //    {
//        //        Console.WriteLine(-i);
//        //    }
//        //}

//        //public static int[] getArray() { return null; }

//        //private static void Main(string[] args)
//        //{
//        //    int index = 1;
//        //    try
//        //    {
//        //        getArray()[index = 2]++;
//        //    }
//        //    catch (Exception)
//        //    {
//        //        //empty catch
//        //    }
//        //    Console.WriteLine("index = {0}", index);
//        //}

//        //private static void Main(string[] args)
//        //{
//        //    unchecked
//        //    {
//        //        short s = short.MinValue;
//        //        char c = (char)s;
//        //        Console.WriteLine((int)c);
//        //    }
//        //}

//        //private static void Main(string[] args)
//        //{
//        //    try
//        //    {
//        //        int[] a = null;
//        //        int i = a[Do(true)];
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        Console.WriteLine(e.GetType());
//        //        Console.WriteLine(e.Message);
//        //    }
//        //}

//        //public static int Do(bool b)
//        //{
//        //    if (b)
//        //        throw new Exception("Some Exception");
//        //    return 0;
//        //}

//        //private static void Main(string[] args)
//        //{
//        //    int i = 5;
//        //    int j = 7;
//        //    int k = --i & j & i;
//        //    m(out k);
//        //    try
//        //    {
//        //        Console.Write(k);
//        //        return;
//        //    }
//        //    finally
//        //    {
//        //        m(out k);
//        //    }
//        //}

//        //private static void m(out int i)
//        //{
//        //    Console.Write("m");
//        //}
//    }
//}

// Использовать вложенный блок try.
using System;

class NestTrys
{
    static void Main()
    {
        // Здесь массив numer длиннее массива denom.
        int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
        int[] denom = { 2, 0, 4, 4, 0, 8 };
        try
        { 
            // внешний блок try
            for (int i = 0; i < numer.Length; i++)
            {
                try
                { 
                    // вложенный блок try
                    Console.WriteLine(numer[i] + " / " + denom[i] + " равно " + numer[i] / denom[i]);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Делить на нуль нельзя!");
                }
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Подходящий элемент не найден.");
            Console.WriteLine("Неисправимая ошибка - программа прервана.");
        }
    }
}