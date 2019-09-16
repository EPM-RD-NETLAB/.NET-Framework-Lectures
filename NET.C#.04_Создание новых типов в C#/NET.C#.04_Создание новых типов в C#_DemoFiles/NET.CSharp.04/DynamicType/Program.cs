using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicType
{
    class ExampleClass
    {
        public ExampleClass() { }
        public ExampleClass(int v){ }

        public void exampleMethod1(int i)
        {
            throw new NotImplementedException();
        }

        public void exampleMethod2(string str)
        {
            Console.WriteLine(str);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            dynamic dyn = 1;
            object obj = 1;

            // Rest the mouse pointer over dyn and obj to see their
            // types at compile time.
            Console.WriteLine(dyn.GetType());
            Console.WriteLine(obj.GetType());

            dyn = dyn + 3;
            //obj = obj + 3;//CTE

            ExampleClass ec = new ExampleClass();
            // The following line causes a compiler error if exampleMethod1 has only
            // one parameter.
            //ec.exampleMethod1(10, 4);

            dynamic dynamic_ec = new ExampleClass();
            // The following line is not identified as an error by the
            // compiler, but it causes a run-time exception.
            //dynamic_ec.exampleMethod1(10, 4);

            // The following calls also do not cause compiler errors, whether 
            // appropriate methods exist or not.
            //dynamic_ec.someMethod("some argument", 7, null);
            dynamic_ec.exampleMethod2("some argument");
            dynamic_ec.nonexistentMethod();
        }
    }
}
