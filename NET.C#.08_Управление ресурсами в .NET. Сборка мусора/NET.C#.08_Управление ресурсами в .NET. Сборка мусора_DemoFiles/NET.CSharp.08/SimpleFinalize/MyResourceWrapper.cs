using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleFinalize
{
    class MyResourceWrapper
    {
        ~MyResourceWrapper()
        {
            for (int i = 0; i < 5; i++)
            {
                 Console.Beep();
            }
        }
    }
}
