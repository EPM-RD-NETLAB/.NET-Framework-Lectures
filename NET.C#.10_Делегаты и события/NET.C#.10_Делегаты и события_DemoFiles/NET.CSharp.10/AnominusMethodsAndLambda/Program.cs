using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnominusMethodsAndLambda
{       
    delegate int MyDelegate(int number);

    class Program
    {

        // Create an instance of the delegate type.
        MyDelegate myDelegateInstance = null;
        public void addAnonymousMethodsToDelegate()
        {
            // Add an anonymous method to the delegate.
            // Do not specify any parameters.
            myDelegateInstance += new MyDelegate(delegate
            {
                // Perform operation.
                return 5;
            });
            // Add an anonymous method to the delegate.
            // Specify parameters; the parameters must match
            // the signature of the delegate.
            myDelegateInstance += new MyDelegate(delegate(int parameter)
            {
                return 10;
            });
            // Invoke the delegate.
            int returnedValue = myDelegateInstance(2);
            // returnedValue = 10 (as second method is called last).
        }


        static void Main(string[] args)
        {
            MyDelegate myDelegateInstance = null;
            //замыкание 
            int external = 1;
            myDelegateInstance += new MyDelegate(x => x++ * x * external);
            //если в цепочке делегатов возвращается результат, 
            //то промежуточные результаты будут потеряны
            //вернется только последний
            //замыкание 
            external *= 10;
            myDelegateInstance += x => x * x * external;
            var t = myDelegateInstance(6);
        }
    }
}
