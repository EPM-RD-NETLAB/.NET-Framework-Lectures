using System;

namespace NullableValueTypes
{
    public static class Program
    {
        public static void Main()
        {
            UsingNullable();
            ConversionsAndCasting();
            Operators();
            NullableCodeSize(5, 10);
            NullCoalescingOperator();
            Boxing();
            Unboxing();
            GetTypeOfNullable();
        }

        private static void UsingNullable()
        {
            //Nullable <T> - Structure
            //Represents an object whose underlying type is a value type, 
            //which can be set to null, as well as a reference type.
            Nullable<Int32> x = 5; ;
            Nullable<Int32> y = null;
            Console.WriteLine("x: HasValue={0}, Value={1}", x.HasValue, x.Value);
            Console.WriteLine("y: HasValue={0}, Value={1}", y.HasValue, y.GetValueOrDefault());
        }

        private static void ConversionsAndCasting()
        {
            // Implicit conversion from non-nullable Int32 to Nullable<Int32>
            Int32? a = 5;

            // Implicit conversion from ‘null’ to Nullable<Int32>
            Int32? b = null;

            int i = 78;
            a = i;
            // Explicit conversion from Nullable<Int32> to non-nullable Int32
            Int32 c = (Int32)a;
            //Int32 c = a; //!cte

            // Casting between nullable primitive types
            Double? d = 5; // Int32->Double?  (d is 5.0 as a double)
            Double? e = b; // Int32?->Double? (e is null)
        }

        private static void Operators()
        {
            Int32? a = 5;
            Int32? b = null;

            // Unary operators (+  ++  -  --  !  ~)
            a++;    // a = 6
            b = -b; // b = null

            // Binary operators (+  -  *  /  %  &  |  ^  <<  >>)
            a = a + 3;  // a = 9
            b = b * 3;  // b = null;

            // Equality operators (== !=)
            if (a == null) { /* no  */ } else { /* yes */ }
            if (b == null) { /* yes */ } else { /* no  */ }
            if (a != b) { /* yes */ } else { /* no  */ }

            // Comparison operators (<, >, <=, >=)
            if (a < b) { /* no  */ } else { /* yes */ }
        }

        private static Int32? NullableCodeSize(Int32? a, Int32? b)
        {
            return a + b;
        }

        private static void NullCoalescingOperator()
        {
            Int32? b = null;


            //The ?? operator is called the null-coalescing operator 
            //and is used to define a default value for a nullable value 
            //types as well as reference types. It returns the left-hand
            //operand if it is not null; otherwise it returns the right operand.

            // The line below is equivalent to:
            // x = (b.HasValue) ? b.Value : 123
            Int32 x = b ?? 123;
            Console.WriteLine(x);  // "123"

            // The line below is equivalent to:
            // String temp = GetFilename();
            // filename = (temp != null) ? temp : "Untitled";
            String filename = GetFilename() ?? "Untitled";
        }

        private static String GetFilename() { return null; }

        private static void Boxing()
        {
            // Boxing Nullable<T> is null or boxed T
            Int32? n = null;
            Object o = n;  // o is null
            Console.WriteLine("o is null={0}", o == null);   // "True"


            n = 5;
            o = n;   // o refers to a boxed Int32
            Console.WriteLine("o's type={0}", o.GetType()); // "System.Int32"
        }

        private static void Unboxing()
        {
            // Create a boxed Int32
            Object o = 5;

            // Unbox it into a Nullable<Int32> and into an Int32
            Int32? a = (Int32?)o; // a = 5
            Int32 b = (Int32)o;  // b = 5

            // Create a reference initialized to null
            o = null;

            // “Unbox” it into a Nullable<Int32> and into an Int32
            a = (Int32?)o;       // a = null
            //b = (Int32)o;       // NullReferenceException
        }

        private static void GetTypeOfNullable()
        {
            Int32? x = 5;

            // The line below displays "System.Int32"; 
            // not "System.Nullable<Int32>"!!!"lying"
            Console.WriteLine(x.GetType());
        }
    }
}
