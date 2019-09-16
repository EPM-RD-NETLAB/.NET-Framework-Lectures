using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassForUnitTest
{
    public class Class1
    {
        public static int DoCalculations(string s)
        {
            int result;
            if (int.TryParse(s, out result))
            {
                return (int)Math.Pow(result, 3);
            }
            else
            {
                throw new Exception("It's not a number");
            }
        }
    }
}
