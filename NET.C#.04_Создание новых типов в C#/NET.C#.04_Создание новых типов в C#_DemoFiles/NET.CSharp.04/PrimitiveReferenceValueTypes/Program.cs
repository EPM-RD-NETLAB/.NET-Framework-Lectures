using System;
using System.Collections;

namespace PrimitiveReferenceValueTypes
{
    public static class Program
    {
        public static void Main()
        {
            PrimitiveDemo();
            BoxingDemo();
            ReferenceVsValue.Go();
            Boxing.Go();
            BoxingForInterfaceMethod.Go();
            MutateViaInterface.Go();
        }

        private static void PrimitiveDemo()
        {
            // The following 4 lines generate identical IL code
            int a = new int();
            int b = 0;
            System.Int32 c = new System.Int32();
            Int32 d = 0;

            // Show that all variables contain 0
            Console.WriteLine("a = {0}, b = {1}, c = {2}, d = {3}", new Object[] { a, b, c, d });

            // Make all variables contain 5
            a = b = c = d = 5;
            // Show that all variables contain 5
            Console.WriteLine("a = {0}, b = {1}, c = {2}, d = {3}", new Object[] { a, b, c, d });
        }

        private static void BoxingDemo()
        {
            Int32 a = 5;  // Create an unboxed value type variable
            Object o = a;  // o refers to a boxed version of a
            a = 123;       // Changes the unboxed value to 123, but not object o
            Console.WriteLine(a + ", " + (Int32)o);  // Displays "123, 5"
            Console.WriteLine(a + ", " + o);	         // Better? because without unboxing!

            Console.WriteLine(a);   // No boxing
        }

        private static class ReferenceVsValue
        {
            // Reference type (because of 'class')
            private class SomeRef
            {
                public Int32 x;
            }

            // Value type (because of 'struct')
            private struct SomeVal
            {
                public Int32 x;
            }

            public static void Go()
            {
                SomeRef r1 = new SomeRef();   // Allocated in heap
                SomeVal v1 = new SomeVal();   // Allocated on stack
                r1.x = 5;                     // Pointer dereference
                v1.x = 5;                     // Changed on stack
                Console.WriteLine(r1.x);      // Displays "5"
                Console.WriteLine(v1.x);      // Also displays "5"
                // The left side of Figure 5-2 reflects the situation
                // after the lines above have executed.

                SomeRef r2 = r1;              // Copies reference (pointer) only
                SomeVal v2 = v1;              // Allocate on stack & copies members
                r1.x = 8;                     // Changes r1.x and r2.x
                v1.x = 9;                     // Changes v1.x, not v2.x
                Console.WriteLine(r1.x);      // Displays "8"
                Console.WriteLine(r2.x);      // Displays "8"
                Console.WriteLine(v1.x);      // Displays "9"
                Console.WriteLine(v2.x);      // Displays "5"
                // The right side of Figure 5-2 reflects the situation 
                // after ALL the lines above have executed.
            }
        }

        private static class Boxing
        {
            public static void Go()
            {
                ArrayList a = new ArrayList();
                Point p;            // Allocate a Point (not in the heap).
                for (Int32 i = 0; i < 10; i++)
                {
                    p.x = p.y = i;   // Initialize the members in the value type.
                    a.Add(p);        // Box the value type and add the reference to the Arraylist.
                }
            }

            // Declare a value type.
            private struct Point
            {
                public Int32 x, y;
            }

            public static void Main2()
            {
                Int32 x = 5;
                Object o = x;         // Box x; o refers to the boxed object
                Int16 y = (Int16)o;   // Throws an InvalidCastException
            }

            public static void Main3()
            {
                Int32 x = 5;
                Object o = x;                 // Box x; o refers to the boxed object
                Int16 y = (Int16)(Int32)o;    // Unbox to the correct type and cast
            }

            public static void Main4()
            {
                Point p;
                p.x = p.y = 1;
                Object o = p;   // Boxes p; o refers to the boxed instance

                p = (Point)o;  // Unboxes o AND copies fields from boxed 
                // instance to stack variable
            }

            public static void Main5()
            {
                Point p;
                p.x = p.y = 1;
                Object o = p;   // Boxes p; o refers to the boxed instance

                // Change Point’s x field to 2
                p = (Point)o;  // Unboxes o AND copies fields from boxed 
                // instance to stack variable
                p.x = 2;        // Changes the state of the stack variable
                o = p;          // Boxes p; o refers to a new boxed instance
            }

            public static void Main6()
            {
                Int32 v = 5;            // Create an unboxed value type variable.
                Object o = v;            // o refers to a boxed Int32 containing 5.
                v = 123;                 // Changes the unboxed value to 123

                Console.WriteLine(v + ", " + (Int32)o);	// Displays "123, 5"
            }

            public static void Main7()
            {
                Int32 v = 5;                // Create an unboxed value type variable.
                Object o = v;               // o refers to the boxed version of v.

                v = 123;                    // Changes the unboxed value type to 123
                Console.WriteLine(v);       // Displays "123"

                v = (Int32)o;               // Unboxes and copies o into v
                Console.WriteLine(v);       // Displays "5"
            }

            public static void Main8()
            {
                Int32 v = 5;   // Create an unboxed value type variable.

#if INEFFICIENT
    // When compiling the following line, v is boxed 
    // three times, wasting time and memory.
   Console.WriteLine("{0}, {1}, {2}", v, v, v);
#else
                // The lines below have the same result, execute
                // much faster, and use less memory.
                Object o = v;  // Manually box v (just once).

                // No boxing occurs to compile the following line.
                Console.WriteLine("{0}, {1}, {2}", o, o, o);
#endif
            }
        }

        private static class BoxingAndInterfaces
        {
            private struct Point : ICloneable
            {
                public Int32 x, y;

                // Override ToString method inherited from System.ValueType
                public override String ToString()
                {
                    return String.Format("({0}, {1})", x, y);
                }

                // Implementation of ICloneable’s Clone method
                public Object Clone()
                {
                    return MemberwiseClone();
                }
            }

            public static void Go()
            {
                // Create an instance of the Point value type on the stack.
                Point p;

                // Initialize the instance’s fields.
                p.x = 10;
                p.y = 20;

                // p does NOT get boxed to call ToString.
                Console.WriteLine(p.ToString());

                // p DOES get boxed to call GetType.
                Console.WriteLine(p.GetType());

                // p does NOT get boxed to call Clone.
                // Clone returns an object that is unboxed,
                // and its fields are copied into p2.
                Point p2 = (Point)p.Clone();

                // p2 DOES get boxed, and the reference is placed in c.
                ICloneable c = p2;

                // c does NOT get boxed because it is already boxed.
                // Clone returns a reference to an object that is saved in o.
                Object o = c.Clone();

                // o is unboxed, and fields are copied into p.
                p = (Point)o;
            }
        }

        private static class BoxingForInterfaceMethod
        {
            private struct Point : IComparable
            {
                private Int32 m_x, m_y;

                // Constructor to easily initialize the fields
                public Point(Int32 x, Int32 y)
                {
                    m_x = x;
                    m_y = y;
                }

                // Override ToString method inherited from System.ValueType
                public override String ToString()
                {
                    // Return the point as a string
                    return String.Format("({0}, {1})", m_x, m_y);
                }

                // Implementation of type-safe CompareTo method
                public Int32 CompareTo(Point other)
                {
                    // Use the Pythagorean Theorem to calculate 
                    // which point is farther from the origin (0, 0)
                    return Math.Sign(Math.Sqrt(m_x * m_x + m_y * m_y)
                                     - Math.Sqrt(other.m_x * other.m_x + other.m_y * other.m_y));
                }

                // Implementation of IComparable’s CompareTo method
                public Int32 CompareTo(Object o)
                {
                    if (GetType() != o.GetType())
                    {
                        throw new ArgumentException("o is not a Point");
                    }
                    // Call type-safe CompareTo method
                    return CompareTo((Point)o);
                }
            }

            public static void Go()
            {
                // Create two Point instances on the stack.
                Point p1 = new Point(10, 10);
                Point p2 = new Point(20, 20);

                // p1 does NOT get boxed to call ToString (a virtual method).
                Console.WriteLine(p1.ToString());	// "(10, 10)"

                // p DOES get boxed to call GetType (a non-virtual method).
                Console.WriteLine(p1.GetType());	// "Point"

                // p1 does NOT get boxed to call CompareTo.
                // p2 does NOT get boxed because CompareTo(Point) is called.
                Console.WriteLine(p1.CompareTo(p2));	// "-1"

                // p1 DOES get boxed, and the reference is placed in c.
                IComparable c = p1;
                Console.WriteLine(c.GetType());	// "Point"

                // p1 does NOT get boxed to call CompareTo.
                // Since CompareTo is not being passed a Point variable, 
                // CompareTo(Object) is called which requires a reference to
                // a boxed Point. 
                // c does NOT get boxed because it already refers to a boxed Point.
                Console.WriteLine(p1.CompareTo(c));	// "0"

                // c does NOT get boxed because it already refers to a boxed Point.
                // p2 does get boxed because CompareTo(Object) is called.
                Console.WriteLine(c.CompareTo(p2));	// "-1"
                var myObj = (int?)null;
                myObj = 78;


                // c is unboxed, and fields are copied into p2.
                p2 = (Point)c;

                // Proves that the fields got copied into p2.
                Console.WriteLine(p2.ToString());	// "(10, 10)"
            }
        }

        private static class MutateViaInterface
        {
            // Interface defining a Change method
            private interface IChangeBoxedPoint
            {
                void Change(Int32 x, Int32 y);
            }

            // Point is a value type.
            private struct Point : IChangeBoxedPoint
            {
                private Int32 _mX, _mY;

                public Point(Int32 x, Int32 y)
                {
                    _mX = x;
                    _mY = y;
                }

                public void Change(Int32 x, Int32 y)
                {
                    _mX = x; _mY = y;
                }

                public override String ToString()
                {
                    return String.Format("({0}, {1})", _mX, _mY);
                }
            }

            public static void Go()
            {
                Point p = new Point(1, 1);

                Console.WriteLine(p);

                p.Change(2, 2);
                Console.WriteLine(p);

                Object o = p;
                Console.WriteLine(o);

                ((Point)o).Change(3, 3);//!!!(2,2)
                Console.WriteLine(o);

                //C# can not change fields in packaged form, but
                //but you can apply the interface
                // Boxes p, changes the boxed object and discards it
                ((IChangeBoxedPoint)p).Change(4, 4);
                Console.WriteLine(p);

                // Changes the boxed object and shows it
                ((IChangeBoxedPoint)o).Change(5, 5);
                Console.WriteLine(o);
            }
        }
    }
}
