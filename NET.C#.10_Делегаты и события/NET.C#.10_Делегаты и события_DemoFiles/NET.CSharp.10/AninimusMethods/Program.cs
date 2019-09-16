using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AninimusMethods
{
    class Program
    {
        delegate int myDelegate(int number);

        public void addAnonymousMethodsToDelegate()
        {
            myDelegate myDelegateInstance = null;
            // Add an anonymous method to the delegate.
            // Do not specify any parameters.
            myDelegateInstance += new myDelegate(delegate
            {
                // Perform operation.
                return 5;
            });
            // Add an anonymous method to the delegate.
            // Specify parameters; the parameters must match
            // the signature of the delegate.
            myDelegateInstance += new myDelegate(delegate(int parameter)
            {
                return 10;
            });
            // Invoke the delegate.
            int returnedValue = myDelegateInstance(2);
            // returnedValue = 10 (as second method is called last).
        }
    }
}
