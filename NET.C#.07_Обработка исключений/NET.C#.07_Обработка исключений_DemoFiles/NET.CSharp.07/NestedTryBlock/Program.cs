using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NestedTryBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Outer try block.
                //...
                try
                {
                    //throw new FileNotFoundException();// Nested try block
                    //throw  new DivideByZeroException();
                    throw new ArgumentOutOfRangeException();
                }
                catch (FileNotFoundException ex)
                {
                    // Catch block for nested try block
                }
                //...
                // Outer try block continued
            }
            catch (DivideByZeroException ex)
            {
                // Catch block, can access DivideByZeroException exception in ex.
            }
            catch (Exception ex)
            {
                // Catch block, can access exception in ex.
            }
        }
    }
}