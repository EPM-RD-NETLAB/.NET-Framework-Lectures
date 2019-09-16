using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Parameters
{
    class Program
    {

        static void Main(string[] args)
        {
            OptionalAndNamedParameters.Go();
            MethodsThatTakeVariableArguments.Go();
            OutAndRefParameters.SomeMethod();
            OutAndRefParameters.SomeMethod2();
            OutAndRefParameters.Go();
            Console.ReadKey();
        }
    }

    internal static class OptionalAndNamedParameters
    {
        private static Int32 _sN = 0;

        public static void Go()
        {
            //ImplicitlyTypedLocalVariables();

            // 1. Same as: M(9, "A", default(DateTime), new Guid());
            //M();

            // 2. Same as: M(8, "X", default(DateTime), new Guid());
            //M(8, "X");

            // 3. Same as: M(5, "A", DateTime.Now, Guid.NewGuid());
            // M(5, guid: Guid.NewGuid(), dt: DateTime.Now);

            // 4. Same as: M(0, "1", default(DateTime), new Guid());
            //M(_sN++, _sN++.ToString());

            // 5. Same as: String t1 = "2"; Int32 t2 = 3;M(t2, t1, default(DateTime), new Guid()); 
            M(s: (_sN++).ToString(), x: _sN++);
        }

        private static void M(Int32 x = 9, String s = "A", DateTime dt = new DateTime(), Guid guid = new Guid())
        {
            Console.WriteLine("x={0}, s={1}, dt={2}, guid={3}", x, s, dt, guid);
        }

        //private static void ImplicitlyTypedLocalVariables()
        //{
        //    var name = "Jeff";
        //    ShowVariableType(name);    // Displays: System.String

        //    // var n = null;            // Error
        //    var x = (Exception)null;   // OK, but not much value

        //    ShowVariableType(x);       // Displays: System.Exception

        //    var numbers = new Int32[] { 1, 2, 3, 4 };
        //    ShowVariableType(numbers); // Displays: System.Int32[]

        //    // Less typing for complex types
        //    var collection = new Dictionary<String, Single>() { { ".NET", 4.0f } };

        //    // Displays: System.Collections.Generic.Dictionary`2[System.String,System.Single]
        //    ShowVariableType(collection);

        //    foreach (var item in collection)
        //    {
        //        // Displays: System.Collections.Generic.KeyValuePair`2[System.String,System.Single]
        //        // KeyValuePair - structure defines a key/value pair that can be set or retrieved
        //        ShowVariableType(item);
        //    }
        //}

        //private static void ShowVariableType<T>(T t)
        //{
        //    Console.WriteLine(typeof(T));
        //}
    }

    internal static class OutAndRefParameters
    {

        public static void Go()
        {
            Int32 x;               // x is uninitialized
            SetVal(out x);         // x doesn’t have to be initialized.
            //AddVal(ref x);
            Console.WriteLine(x);  // Displays "10"
        }

        private static void SetVal(out Int32 v)
        {
            v = 10;  // This method must initialize v.
        }

        //private static void SetVal(ref Int32 v)//the same private static void SetVal(out Int32 v)
        //{
        //    v = 10;  // This method must initialize v.
        //}

        private static void AddVal(ref Int32 v)
        {
            v += 10;  // This method can use the initialized value in v.
        }

        public static void Swap(ref Object a, ref Object b)
        {
            Object t = b;
            b = a;
            a = t;
        }

        public static void SomeMethod()
        {
            String s1 = "Jeffrey";
            String s2 = "Richter";
            Swap(ref s1, ref s2);
            Console.WriteLine(s1);  // Displays "Richter"
            Console.WriteLine(s2);  // Displays "Jeffrey"
        }

        public static void SomeMethod2()
        {
            String s1 = "Jeffrey";
            String s2 = "Richter";

            // Variables that are passed by reference must match what the method expects.
            Object o1 = s1, o2 = s2;
            Swap(ref o1, ref o2);

            // Now cast the objects back to strings. 
            s1 = (String)o1;
            s2 = (String)o2;

            Console.WriteLine(s1);  // Displays "Richter"
            Console.WriteLine(s2);  // Displays "Jeffrey"
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T t = b;
            b = a;
            a = t;
        }
    }

    internal static class MethodsThatTakeVariableArguments
    {
        public static void Go()
        {
            // Displays "15"
            Console.WriteLine(Add(new Int32[] { 1, 2, 3, 4, 5 }));

            // Displays "15"
            Console.WriteLine(Add(1, 2, 3, 4, 5));

            // Displays "15"
            Int32[] arr = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(Add(arr));
            Console.WriteLine(AddArr(arr));

            //Display 6 
            //Caused by an overloaded method
            Console.WriteLine(Add(1, 2, 3));

            // Displays "0"
            Console.WriteLine(Add());

            //Console.WriteLine(AddArr(1, 2, 3, 4));//Error
            Console.WriteLine(AddArr(new int[] { 1, 2, 3, 4, 5 }));

            DisplayTypes(new Object(), new Random(), "Jeff", 5);
        }

        private static Int32 Add(params Int32[] values)
        {
            // NOTE: it is possible to pass the 'values' 
            // array to other methods if you want to.

            Int32 sum = 0;
            for (Int32 x = 0; x < values.Length; x++)
                sum += values[x];
            return sum;
        }

        //private static Int32 Add(Int32[] values)//the same private static Int32 Add(params Int32[] values)
        private static Int32 AddArr(Int32[] values)
        {
            Int32 sum = 0;
            for (Int32 x = 0; x < values.Length; x++)
                sum += values[x];
            return sum;
        }

        private static Int32 Add(int one, int two, int three)
        {
            return one + two + three;
        }

        private static void DisplayTypes(params Object[] objects)
        {
            foreach (Object o in objects)
                Console.WriteLine(o.GetType());
            Console.WriteLine();
        }
    }
}
